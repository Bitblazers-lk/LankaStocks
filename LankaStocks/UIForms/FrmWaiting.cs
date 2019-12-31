using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using LankaStocks.Setting;
using static LankaStocks.Core;

namespace LankaStocks.UIForms
{
    public partial class FrmWaiting : Form
    {
        readonly System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();

        string _txt;
        public FrmWaiting(ServerStatus status, string TXT = "Waiting For Server")
        {
            _txt = TXT;
            InitializeComponent();
            if (status == ServerStatus.Waiting)
            {
                circularProgressBar1.Maximum = 120;
                aTimer.Tick += new EventHandler(Timer_Tick);
                aTimer.Interval = 800;
                aTimer.Enabled = true;
            }
            else circularProgressBar1.Maximum = 100;
        }
        int i = 0;
        void Timer_Tick(object sender, EventArgs e)
        {
            if (i < 30) label1.Text = _txt + ".";
            else if (i < 60) label1.Text = _txt + "..";
            else if (i < 90) label1.Text = _txt + "...";
            else if (i < 120) label1.Text = _txt + "....";
            circularProgressBar1.Value = i;
            i += 30;
            if (circularProgressBar1.Value > 90)
            {
                i = 0;
                circularProgressBar1.Value = 0;
                label1.Text = _txt + ".";
            }
        }
        private void FrmWaiting_Load(object sender, EventArgs e)
        {
            aTimer.Start();
            Settings.LoadCtrlSettings(this);
            this.BackColor = Color.FromArgb(47, 47, 47);
            circularProgressBar1.BackColor = Color.FromArgb(47, 47, 47);
            label1.Font = new Font(label1.Font.Name.ToString(), label1.Font.Size + 2);
        }
        public void SetPercentage(byte Val)
        {
            if (Val <= circularProgressBar1.Maximum && Val >= circularProgressBar1.Minimum)
                circularProgressBar1.Value = Val;
        }
        public void SetText(string TXT)
        {
            _txt = TXT;
            label1.Text = _txt;
        }
    }

    public enum ServerStatus
    {
        Waiting = 0,
        Downloading
    }
}
