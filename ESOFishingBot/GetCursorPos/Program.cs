using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace GetCursorPos
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine(Cursor.Position);
                Thread.Sleep(500);
            }
        }
    }
}
