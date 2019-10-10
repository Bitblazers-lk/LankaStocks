using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks.dev
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Core.IsDebug = true;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
         
            LankaStocks.Program.Main();
        }

    }
}