using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace shodan_api_final
{
    public partial class search : Form
    {
        public search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main x = new Main();
            x   .Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            //Search Shodan using the same query syntax as the website
            RestApi search = new RestApi();
            string query = string.Empty;
            //group query pairs(property:value) from textboxes 
            bool used = false;
            if (devicetxt.Text.ToString() != "")
            {
                query += devicetxt.Text;
                used = true;
            }
            if (countrytxt.Text.ToString() != "")
            {
                if (used)
                    query += "%20";
                query += "country:" + countrytxt.Text;
                used = true;
            }
            if (citytxt.Text.ToString() != "")
            {
                if (used)
                    query += "%20";
                query += "city:" + citytxt.Text;
                used = true;
            }
            if (isptxt.Text.ToString() != "")
            {

                if (used)
                    query += "%20";
                used = true;
                query += "isp:" + isptxt.Text;
            }
            if (porttxt.Text.ToString() != "")
            {

                if (used)
                    query += "%20";
                used = true;
                query += "port:" + porttxt.Text;
            }
            if (ostxt.Text.ToString() != "")
            {

                if (used)
                    query += "%20";
                used = true;
                query += "os:" + ostxt.Text;

            }
            //https://api.shodan.io/shodan/host/search?key={YOUR_API_KEY}&query={query}
            search.endpoint = RestApi.  baseUrl + "host/search?key=" + RestApi.apiKey + "&query=" + query;
            string response = search.makeRequest();
            Dictionary<string, object> x = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
            //the dictionry has 2 keys [total = > total number found , matches = > devices details]
            string tempelate = filter(x["matches"].ToString());
            if (int.Parse(x["total"].ToString()) != 0)//if we found at least one or more device
            {
                try {
                    //filter resoonse json and split into string array
                    String[] all = filter2(filter(x["matches"].ToString()), int.Parse(x["total"].ToString()));
                    for (int i = 0; i < all.Length; i++)
                    {
                        debugOutput("*********DEVICE*********");
                        Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(all[i]);
                        if (data.ContainsKey("ip_str"))
                            debugOutput("ip :  " + data["ip_str"]);
                        if (data.ContainsKey("product"))
                            debugOutput("product :  " + data["product"]);
                        if (data.ContainsKey("os"))
                            debugOutput("operating system :  " + data["os"]);
                        if(data.ContainsKey("server"))
                        debugOutput("server :  " + data["server"]);
                        if (data.ContainsKey("isp"))
                            debugOutput("internet service provider :  " + data["isp"]);
                        if (data.ContainsKey("org"))
                            debugOutput("orgnaization :  " + data["org"]);
                        if (data.ContainsKey("port"))
                            debugOutput("port :  " + data["port"]);
                        if (data.ContainsKey("location"))
                        {
                            Dictionary<string, string> location = JsonConvert.DeserializeObject<Dictionary<string, string>>(data["location"].ToString());
                            if(location.ContainsKey("country_name"))
                            debugOutput("country :  "+location["country_name"]);
                            if (location.ContainsKey("city"))
                                debugOutput("city :  " + location["city"]);
                            if (location.ContainsKey("area_code"))
                                debugOutput("area code :  " + location["area_code"]);
                            if (location.ContainsKey("postal_code"))
                                debugOutput("postal code :  " + location["postal_code"]);
                            if (location.ContainsKey("country_code"))
                                debugOutput("country code :  " + location["country_code"]);
                            if (location.ContainsKey("longitude") && location.ContainsKey("latitude"))
                            {
                                debugOutput("location :  ");
                                debugOutput( location["latitude"] + " latitude and " + location["longitude"] + " longitude");
                            }
                        }
                    }
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("error : "+ex.Message);
                }
                label8.Text = x["total"].ToString() + " devices found";
            }
            else
                MessageBox.Show("No Results Found!");
        }
        //to debug output format
        private void debugOutput(string strDebug)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebug + Environment.NewLine);
                textBox2.Text = textBox2.Text + strDebug + Environment.NewLine;
                textBox2.SelectionStart = textBox2.TextLength;
                textBox2.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message + Environment.NewLine);
            }
        }
       //split data 
        private string[] filter2(string s, int total)
        {
            string[] result = new string[total];
            for (int i = 0; i < total; i++)
                result[i] = "";
            int curritems = 0, curr = 0;
            for (int i = 0; i < s.Length; i++)
            {
                
                if (s[i] == ',' && curr == 0)
                    continue;
                if (s[i] == '{')
                {
                    result[curritems] += s[i];
                    curr++;
                }
                else if (s[i] == '}')
                {
                    curr--;
                    result[curritems] += s[i];
                    if (curr == 0)
                        curritems++;
                }
                else result[curritems] += s[i];
                if (curritems == total)
                    break;
            }
            
            return result;
        }
        //removing [] from string
        private string filter(string s)
        {
           
            string ss = "";
            for (int i = 2; i < s.Length-2; i++)
                    ss += s[i];
            
            return ss;
        }
        


    }
}
