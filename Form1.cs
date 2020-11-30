using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
//using AForge;
//using AForge.Imaging;
//using System.Drawing.Imaging;
//using AForge.Imaging.Filters;
using System.Runtime.CompilerServices;
using static zoombot.schedule;
using System.Drawing.Imaging;
using AForge.Imaging;
using System.Diagnostics;

namespace zoombot
{


    public partial class Form1 : Form
    {
        public int mx = 0;
        public int my = 0;
        public static new System.Drawing.Point MousePosition { get; }
        string mxdisplay = String.Empty;
        string mydisplay = String.Empty;
        System.Drawing.Point mouse = MousePosition;
        string stringmouse = String.Empty;
        int one = 1;
        bool usesch = false;
        string meetids = schvar.meetids;
        string passs = schvar.passs;
         //Mouse actions

        private System.Windows.Forms.MouseButtons clicked = MouseButtons;
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_MOVE = 0x0001;
        public Form1()
        {
            InitializeComponent();
            //Mousexy();
        }

        public void Mousexy()
        {
            mouse = MousePosition;
            Writ();
        }
        public void Writ()
        {
            if (clicked == MouseButtons) 
            {
                mouse = MousePosition;
                stringmouse = Convert.ToString(mouse);
                //textBox2.Text = stringmouse;            
            }

            //textBox2.Text = stringmouse;
        }
        public void Win()
        {
            string zoom = "zoom";
            Cursor.Position = new System.Drawing.Point(0, 1080);
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            Thread.Sleep(500);
            SendKeys.Send(zoom);
            Thread.Sleep(500);
            openzoom();
        }

        private void CaptureMyScreen()

        {

            try

            {

                //Creating a new Bitmap object

                Bitmap captureBitmap = new Bitmap(2500, 1500, PixelFormat.Format32bppArgb);


                //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);

                //Creating a Rectangle object which will  

                //capture our Current Screen

                Rectangle captureRectangle = new Rectangle(0, 0, 2500, 1500);



                //Creating a New Graphics Object

                Graphics captureGraphics = Graphics.FromImage(captureBitmap);



                //Copying Image from The Screen

                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);



                //Saving the Image File (I am here Saving it in My E drive).

                captureBitmap.Save(@"C:\Users\psang\Downloads\zoompos1.jpg", ImageFormat.Jpeg);



                //Displaying the Successfull Result



                //findzoom();

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

        }

        public void openzoom()
        {
            //System.Drawing.Bitmap image = (Bitmap)Bitmap.FromFile(@"C:\Users\psang\Downloads\zoompos1.jpg");
            //System.Drawing.Bitmap template = (Bitmap)Bitmap.FromFile(@"C:\Users\psang\Downloads\zoomjoin.jpg");
           // SendKeys.Send("{ENTER}");
            //Thread.Sleep(500);
            string meetid = textBox3.Text;
            string password = textBox2.Text;
            getinmeeting(meetid, password);
        }
        public void getinmeeting(string meetid, string password)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = $"/C start zoommtg://zoom.us/join?confno={meetid}^&pwd={password}";
            process.StartInfo = startInfo;
            process.Start();
            //int lmeettime = 750; 
            //Thread.Sleep(250);
            //SendKeys.SendWait("{ENTER}");
            //Thread.Sleep(750);
            //Thread.Sleep(lmeettime);
            //SendKeys.SendWait(meetid);
            //SendKeys.SendWait("{ENTER}");
            //Thread.Sleep(1500);
            //SendKeys.SendWait(password);
            //Thread.Sleep(750);
            //SendKeys.SendWait("{ENTER}");
            //Thread.Sleep(10000);
            //SendKeys.SendWait("{ENTER}");
        }
        public void findzoom()
        {
            //use this for cam stuff
            System.Drawing.Bitmap sourceImage = (Bitmap)Bitmap.FromFile(@"C:\Users\psang\Downloads\zoompos1.jpg");
            System.Drawing.Bitmap temp = (Bitmap)Bitmap.FromFile(@"C:\Users\psang\Downloads\zoomjoin.jpg");
            // create template matching algorithm's instance
            // (set similarity threshold to 92.1%)

            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0.921f);
            // find all matchings with specified above similarity

            TemplateMatch[] matchings = tm.ProcessImage(sourceImage, temp);
            // highlight found matchings

            BitmapData data = sourceImage.LockBits(
            new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
            ImageLockMode.ReadWrite, sourceImage.PixelFormat);
            foreach (TemplateMatch m in matchings)
            {

                Drawing.Rectangle(data, m.Rectangle, Color.White);

                MessageBox.Show(m.Rectangle.Location.ToString());
                // do something else with matching
            }
            sourceImage.UnlockBits(data);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = MousePosition;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openzoom();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            zoomweb zoomweb = new zoomweb(); //this is the change, code for redirect  
            zoomweb.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            schedule schedule = new schedule(); //this is the change, code for redirect  
            schedule.ShowDialog();
            usesch = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    public class def
    {

        public Bitmap template = (Bitmap)Bitmap.FromFile(@"C:\Users\psang\Downloads\zoomjoin.jpg");
        public Bitmap image = (Bitmap)Bitmap.FromFile(@"C: \Users\psang\Downloads\zoomjoin.jpg");
    }
}