using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zoombot
{
    public partial class zoomweb : Form
    {
        public zoomweb()
        {
            InitializeComponent();
            webBrowser1.Hide();

        }

        private void zoomweb_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            webBrowser1.Url = new System.Uri(url);
            label1.Hide();
            textBox1.Hide();
            button1.Hide();
            webBrowser1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1(); //this is the change, code for redirect  
            form1.ShowDialog();
        }
    }
}
