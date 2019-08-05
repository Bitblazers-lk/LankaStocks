using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LankaStocks.Core;

namespace LankaStocks.Setting
{
    [Serializable]
    public class BillSettings
    {
        public string H1;
        public string H2;
        public string H3;
        public string E1;
        public string E2;
        public string E3;
        public bool PrintBill;
        public bool Perview;
    }

    [Serializable]
    public class CommonSettings
    {
        public Color MenuColor;
        public Color BackColor;
        public Color ItemColor;
        public Color FontColor;
        public Font Font;
        public string ImagePath;
        public bool OpenAtStat;
    }

    public static class Settings
    {
        public static void LoadCtrlSettings(Control Ctrl)
        {
            Ctrl.BackColor = Color.White;
            try
            {
                foreach (Control ctrl in Ctrl.Controls)
                {
                    LoadCtrlSettings(ctrl);
                }
            }
            catch (Exception ex) { Core.LogErr(ex); }
        }
    }
}
