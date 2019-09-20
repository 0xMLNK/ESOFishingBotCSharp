using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace derMelnik.ESOfishBot
{
    class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        static void Main(string[] args)
        {
            IntPtr WindowName = FindWindow(null, "Elder Scrolls Online");
            if (WindowName == IntPtr.Zero)
            {
                MessageBox.Show("Game is not running.");
                return;
            }

            Point p = new Point();
            p.X = Screen.PrimaryScreen.Bounds.Width / 2 - 485;
            p.Y = 2;
            
            Color idlecolor = new Color();
            Color processcolor = new Color();
            Color hookcolor = new Color();

            idlecolor = Color.FromArgb(255, 101, 69, 0);
            processcolor = Color.FromArgb(255, 75, 156, 213);
            hookcolor = Color.FromArgb(255, 0, 204, 0);
            int counter = 0;

            while(WindowName != IntPtr.Zero)
            { 

                if (Pixelcolor.GetPixel(p) == idlecolor)
                {
                    Console.WriteLine("Statr Fishing");
                    Thread.Sleep(1000);
                    PostMessage(WindowName, 0x100, (IntPtr)Keys.E, IntPtr.Zero);
                    Thread.Sleep(100);
                    PostMessage(WindowName, 0x101, (IntPtr)Keys.E, IntPtr.Zero);
                }
                else if (Pixelcolor.GetPixel(p) == processcolor)
                {
                    Console.WriteLine("Fishing in progerss");
                    Thread.Sleep(200);
                }
                else if (Pixelcolor.GetPixel(p) == hookcolor)
                {
                    Thread.Sleep(1000);
                    PostMessage(WindowName, 0x100, (IntPtr)Keys.E, IntPtr.Zero);
                    Thread.Sleep(100);
                    PostMessage(WindowName, 0x101, (IntPtr)Keys.E, IntPtr.Zero);
                    Console.WriteLine("Gocha");
                    counter++;
                    Console.WriteLine("Total: " + counter);
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("No Fish here, find new FishingHole.");
                }
                Thread.Sleep(1000);
            }

        }
    }
}
//28 5 244