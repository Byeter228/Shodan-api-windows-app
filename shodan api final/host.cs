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
    public partial class host : Form
    {
        public host()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main x = new Main();
            x.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            RestApi search = new RestApi();
            //https://api.shodan.io/shodan/host/{ip}?key={YOUR_API_KEY}
            search.endpoint = RestApi.baseUrl + "host/" + ipTxt.Text + "?key=" + RestApi.apiKey + "&minify=true";
            string response = search.makeRequest();
            //convert the response json array into dictionery then display it
            Dictionary<string, object> x = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
            string temp1 = string.Empty;
            Int64 temp2 = 1;
            try
            {
                foreach (var item in x)
                {
                    if (item.Value != null)//shouldn't display null values or non (string / integer) values
                    {
                        string key = (item.Key), value = (item.Value.ToString());
                        if (item.Value.GetType() == temp1.GetType() || item.Value.GetType() == temp2.GetType())
                            debugOutput(key + " : " + value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //remove [] from json array
        private string prepare(object ss)
        {
            string x = "";
            string s = ss.ToString();
            for (int i = 1; i < s.Length - 1; i++)
                x += s[i];
            return x;
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
    }
}
