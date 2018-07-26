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
    public partial class ports : Form
    {
        public ports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main x = new Main();
            x.Show();
            this.Hide();
        }

        private void ports_Load(object sender, EventArgs e)
        {
            //This method returns a list of port numbers that the crawlers are looking for.
            RestApi ports = new RestApi();
            //https://api.shodan.io/shodan/ports?key={YOUR_API_KEY}
            ports.endpoint = RestApi.baseUrl + "ports?key=" + RestApi.apiKey;
            string response = ports.makeRequest();
            //remove unneccassry [] and split json array into array of string
            string[] portsTotal = Format(response).Split(',');
            label2.Text = portsTotal.Length.ToString() + " total ports";
            //show ports
            for (int i = 0; i < portsTotal.Length; i++)
                debugOutput(portsTotal[i]);

        }
        //dbug output format
        private string Format(string s)
        {
            string x = string.Empty;
            x = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ' && s[i] != ']' && s[i] != '[')
                    x += s[i];
            }
            return x;
        }
        private void debugOutput(string strDebug)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebug + Environment.NewLine);
                textBox1.Text = textBox1.Text + strDebug + Environment.NewLine;
                textBox1.SelectionStart = textBox1.TextLength;
                textBox1.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message + Environment.NewLine);
            }
        }
    }
}
