using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace shodan_api_final
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            host x = new host();
            x.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ports x = new ports();
            x.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search x = new search();    
            x.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
            //get the  api key from txt file 
            string line;
            StreamReader file =new StreamReader("apikey.txt");
            while ((line = file.ReadLine()) != null)
            {
                RestApi.apiKey = line;
                
            }   
            file.Close();
            apikey.Text = "Api Key = " + RestApi.apiKey;
        }

        private void Changeapi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ApiKey x = new ApiKey();
            x.Show();
            this.Hide();
        }
    }
}
