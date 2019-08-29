using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks.dev
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Core.IsDebug = true;
            LankaStocks.Program.Main();
        }
    }
}
