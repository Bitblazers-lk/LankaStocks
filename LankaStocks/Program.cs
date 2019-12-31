using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LankaStocks.UIForms;

namespace LankaStocks
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ApplicationExit += Application_ApplicationExit;
            Core.Initialize();
            Forms.login = new Login();
            Application.Run(Forms.login);
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Core.Shutdown();
        }
    }
}
