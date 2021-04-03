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

        static void Main()
        {
            IntPtr WindowName = FindWindow(null, "Elder Scrolls Online");
            if (WindowName == IntPtr.Zero)
            {
                MessageBox.Show("Game is not running.");
                return;
            }

            Point AddonPosition = new Point
            {
                X = Screen.PrimaryScreen.Bounds.Width / 2 - 470,
                Y = 2
            };

            Color idleColor = Color.FromArgb(255, 101, 69, 0);
            Color inProcessColor = Color.FromArgb(255, 75, 156, 213);
            Color timeToHookColor = Color.FromArgb(255, 0, 204, 0);
            int counter = 0;


            while(WindowName != IntPtr.Zero)
            {
                if (Pixelcolor.GetPixel(AddonPosition) == idleColor)
                {
                    Console.WriteLine("Start Fishing");
                    PostMessage(WindowName, 0x100, (IntPtr)Keys.E, IntPtr.Zero);
                    Thread.Sleep(200);
                    PostMessage(WindowName, 0x101, (IntPtr)Keys.E, IntPtr.Zero);
                    Thread.Sleep(1000);

                }
                else if (Pixelcolor.GetPixel(AddonPosition) == inProcessColor)
                {
                    Console.WriteLine("Fishing in progress");
                    Thread.Sleep(200);
                }
                else if (Pixelcolor.GetPixel(AddonPosition) == timeToHookColor)
                {
                    Thread.Sleep(200);
                    PostMessage(WindowName, 0x100, (IntPtr)Keys.E, IntPtr.Zero);
                    Thread.Sleep(200);
                    PostMessage(WindowName, 0x101, (IntPtr)Keys.E, IntPtr.Zero);
                    Console.WriteLine("Gotcha");
                    counter++;
                    Console.WriteLine("Total: " + counter);
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("No Fish here, find new FishingHole.");
                    Thread.Sleep(5000);
                }
                Thread.Sleep(500);
            }

        }
    }
}
