using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LankaStocks.UserControls;
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
        public float WarnWhen;
    }

    public static class Settings
    {
        public static void LoadCtrlSettings(Control Ctrl)
        {
            var Data = RemoteDBs.Settings.commonSettings.Get;

            Ctrl.Font = Data.Font;
            Ctrl.ForeColor = Data.FontColor;

            try
            {
                if (Ctrl is TextBox || Ctrl is MaskedTextBox || Ctrl is ComboBox) Ctrl.BackColor = Data.ItemColor;
                else if (Ctrl is Panel || Ctrl is TableLayoutPanel || Ctrl is SplitContainer) Ctrl.BackColor = Data.BackColor;
#pragma warning disable CS0642 // Possible mistaken empty statement
                else if (Ctrl is Button || Ctrl is PictureBox || Ctrl is Label) ;
#pragma warning restore CS0642 // Possible mistaken empty statement
                else if (Ctrl is UItem) return;
                else Ctrl.BackColor = Data.BackColor;

                foreach (Control ctrl in Ctrl.Controls)
                {
                    LoadCtrlSettings(ctrl);
                }
            }
            catch (Exception ex) { Core.LogErr(ex); }
        }
    }
}
