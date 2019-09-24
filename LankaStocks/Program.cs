using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LankaStocks.UIForms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Grid;

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

            Core.Initialize();
            Forms.login = new Login();
            Application.Run(Forms.login);
        }
    }
}
