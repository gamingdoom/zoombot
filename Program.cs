using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using AForge;
using AForge.Imaging;
using System.Drawing.Imaging;
using AForge.Imaging.Filters;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace zoombot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public static class Search
    {

        public static bool IsSearchedImageFound(this Bitmap template, Bitmap image)
        {
            const Int32 divisor = 4;
            const Int32 epsilon = 10;

            ExhaustiveTemplateMatching etm = new ExhaustiveTemplateMatching(0.90f);

            TemplateMatch[] tm = etm.ProcessImage(
                new ResizeNearestNeighbor(template.Width / divisor, template.Height / divisor).Apply(template),
                new ResizeNearestNeighbor(image.Width / divisor, image.Height / divisor).Apply(image)
                );

            if (tm.Length == 1)
            {
                Rectangle tempRect = tm[0].Rectangle;

                if (Math.Abs(image.Width / divisor - tempRect.Width) < epsilon
                    &&
                    Math.Abs(image.Height / divisor - tempRect.Height) < epsilon)
                {
                    return true;
                }
            }

            return false;
        }
    }
}


