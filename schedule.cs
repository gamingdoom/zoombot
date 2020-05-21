using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace zoombot
{
    
    public partial class schedule : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_MOVE = 0x0001;


        public schedule()
        {
            InitializeComponent();
            hideadds();
        }
        public void hideadds()
        {
            label1.Hide();
            label2.Hide();
            label3.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            button2.Hide();
        }
        public void showadds()
        {
            label1.Show();
            label2.Show();
            label3.Show();
            textBox1.Show();
            textBox2.Show();
            textBox3.Show();
            button2.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            showadds();

        }

        public void button2_Click(object sender, EventArgs e)
        {

            
            hideadds();
            string zoom = "zoom";
            int lmeettime = Convert.ToInt32(textBox1.Text);
            lmeettime = lmeettime * 60;
            lmeettime = lmeettime * 1000;
            Thread.Sleep(lmeettime);
            Cursor.Position = new System.Drawing.Point(0, 1080);
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            Thread.Sleep(500);
            SendKeys.Send(zoom);
            Thread.Sleep(500);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(1500);
            string meetid = textBox2.Text;
            string password = textBox3.Text;
            Thread.Sleep(500);
            Thread.Sleep(250);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(750);
            SendKeys.SendWait(meetid);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1500);
            SendKeys.SendWait(password);
            Thread.Sleep(750);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(10000);
            SendKeys.SendWait("{ENTER}");
        }
        public class schvar
        {
            public static string meetids = String.Empty;
            public static string passs = String.Empty;
            public static int meettime = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1(); //this is the change, code for redirect  
            form1.ShowDialog();
        }
    }
}
