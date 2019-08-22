using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        public bool Show_Notifications;
    }

    public static class Settings
    {
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENT_LEFTDOWN = 0x02;
        private const int MOUSEEVENT_LEFTUP = 0x04;
        private const int MOUSEEVENT_MIDDLEDOWN = 0x20;
        private const int MOUSEEVENT_MIDDLEUP = 0x40;
        private const int MOUSEEVENT_RIGHTDOWN = 0x08;
        private const int MOUSEEVENT_RIGHTUP = 0x10;

        public static void Virtual_Mouse_Move(int X, int Y)
        {
            mouse_event(1, X, Y, 0, 0);
        }


        private static void Virtual_KeyPress(string txt)
        {
            const int WM_SYSKEYDOWN = 0x0104;
            const int VK_F5 = 0x74;

            IntPtr WindowToFind = FindWindow(null, "Google - Mozilla Firefox");

            PostMessage(WindowToFind, WM_SYSKEYDOWN, VK_F5, 0);
        }

        public static void LoadCtrlSettings(Form frm)
        {
            frm.Font = RemoteDBs.Settings.commonSettings.Get.Font;
            foreach (Control ctrl in frm.Controls)
            {
                LoadCtrlSettings(ctrl);
            }
        }
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


        /// <summary>
        /// Do not use this
        /// </summary>
        /// <param name="frm"></param>
        public static void FocusFrm(Form frm)
        {
            SetWindowPos(frm.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }
    }
}
