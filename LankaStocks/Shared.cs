using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LankaStocks.Shared
{
    public static class Error
    {
        public static string[] Errors = { "Feild Cannot Be Empty!", "Feild Must Be A Number!" };

        private static bool ShowError(string txt, Control ctrl)
        {
            ctrl.BackColor = Color.FromKnownColor(KnownColor.Red);
            //Core.Log(txt);
            // MessageBox.Show(txt, "LankaStocks - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        public static bool Num(Control Ctrl)
        {
            if (!string.IsNullOrWhiteSpace(Ctrl.Text))
            {
                if (float.TryParse(Ctrl.Text, out float A))
                {
                    Ctrl.BackColor = Color.FromKnownColor(KnownColor.WindowFrame);
                    return true;
                }
                else
                {
                    //Ctrl.Text = Ctrl.Text.Substring(0, Ctrl.Text.Length - 1);
                    //Ctrl.Select();
                    return ShowError(Errors[1], Ctrl);
                }
            }
            else return ShowError(Errors[0], Ctrl);
        }

        public static bool Txt(Control Ctrl)
        {
            if (!string.IsNullOrWhiteSpace(Ctrl.Text))
            {
                Ctrl.BackColor = Color.FromKnownColor(KnownColor.WindowFrame);
                return true;
            }
            else return ShowError(Errors[0], Ctrl);
        }
    }
}
