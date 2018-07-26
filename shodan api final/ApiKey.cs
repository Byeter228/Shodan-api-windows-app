using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shodan_api_final
{
    public partial class ApiKey : Form
    {
        public ApiKey()
        {
            InitializeComponent();
        }

        private void ApiKey_Load(object sender, EventArgs e)
        {
            api.Text = RestApi.apiKey;
        }

        private void save_Click(object sender, EventArgs e)
        {
            //change apikey and add to file
            RestApi.apiKey = api.Text;
            using (var file = File.Exists("apikey.txt") ? File.Open("apikey.txt", FileMode.Append) : File.Open("apikey.txt", FileMode.CreateNew))
            using (var stream = new StreamWriter(file))
                stream.WriteLine(api.Text);
            MessageBox.Show("Done !");
        }

        private void bck_Click(object sender, EventArgs e)
        {
            Main x = new Main();
            x.Show();
            this.Hide();
        }
    }
}
