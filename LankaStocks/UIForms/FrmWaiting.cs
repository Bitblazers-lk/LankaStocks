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
        System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();

        public FrmWaiting()
        {
            InitializeComponent();
            aTimer.Tick += new EventHandler(timer_Tick);
            aTimer.Interval = 800;
            aTimer.Enabled = true;
            //x:
            //for (int i = 0; i <= 4; i ++)
            //{
            //    if (i <= 30) label1.Text="Waiting For Server.";
            //    else if (i <= 60) label1.Text = "Waiting For Server..";
            //    else if (i <= 90) label1.Text = "Waiting For Server...";
            //    circularProgressBar1.Value = i*25;
            //    Thread.Sleep(300);
            //}
            //goto x;
        }
        int i = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            if (i < 30) label1.Text = "Waiting For Server.";
            else if (i < 60) label1.Text = "Waiting For Server..";
            else if (i < 90) label1.Text = "Waiting For Server...";
            else if (i < 120) label1.Text = "Waiting For Server....";
            circularProgressBar1.Value = i;           
            i += 30;
            if (circularProgressBar1.Value > 90)
            {
                i = 0;
                circularProgressBar1.Value = 0;
                label1.Text = "Waiting For Server.";
            }
        }

        private void FrmWaiting_Load(object sender, EventArgs e)
        {
            aTimer.Start();
            Settings.LoadCtrlSettings(this);
            this.BackColor = Color.FromArgb(47,47,47);
            circularProgressBar1.BackColor = Color.FromArgb(47, 47, 47);
            label1.Font = new Font(label1.Font.Name.ToString(), label1.Font.Size + 2);
        }
    }
}
