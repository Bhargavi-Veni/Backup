using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ZoomTokenGenerator : Form
    {
        public ZoomTokenGenerator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tokenUrl = "https://zoom.us/oauth/token?grant_type=authorization_code&code={0}&redirect_uri={1}";
            try
            {
                string error;
                var url = string.Format(tokenUrl, textBox7.Text, textBox6.Text);
                var output = WebApiHelper.GetToken(url, textBox3.Text, textBox4.Text, out error);
                if (string.IsNullOrEmpty(error))
                {
                    textBox1.Text = output.access_token;
                    textBox2.Text = output.refresh_token;
                }
                else
                    textBox2.Text = error;
            }
            catch (Exception ex)
            {
                textBox2.Text = ex.Message + " " + ex.StackTrace;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
