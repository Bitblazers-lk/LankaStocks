using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LankaStocks.Setting;
using static LankaStocks.Core;

namespace LankaStocks.UIForms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.gb.Location = new System.Drawing.Point(30, 73);
        }

        public Point downPoint = Point.Empty;
        bool ani = true;

        private void Login_Load(object sender, EventArgs e)
        {
            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.tableLayoutPanel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;

            this.line.BackColor = RemoteDBs.Settings.commonSettings.Get.FontColor;

            this.buttonabout.Font = RemoteDBs.Settings.commonSettings.Get.Font;
            this.buttonabout.ForeColor = RemoteDBs.Settings.commonSettings.Get.FontColor;

            this.buttonlogin.Font = RemoteDBs.Settings.commonSettings.Get.Font;
            this.buttonlogin.ForeColor = RemoteDBs.Settings.commonSettings.Get.FontColor;

            this.BtnLogin.ForeColor = RemoteDBs.Settings.commonSettings.Get.FontColor;

            this.label1.ForeColor = RemoteDBs.Settings.commonSettings.Get.FontColor;
            this.label2.ForeColor = RemoteDBs.Settings.commonSettings.Get.FontColor;
            this.label3.ForeColor = RemoteDBs.Settings.commonSettings.Get.FontColor;
            this.label4.ForeColor = RemoteDBs.Settings.commonSettings.Get.FontColor;
            this.label5.ForeColor = RemoteDBs.Settings.commonSettings.Get.FontColor;
            this.label6.ForeColor = RemoteDBs.Settings.commonSettings.Get.FontColor;

            this.label5.Font = RemoteDBs.Settings.commonSettings.Get.Font;
            this.label6.Font = RemoteDBs.Settings.commonSettings.Get.Font;

            this.BtnLogin.Font = RemoteDBs.Settings.commonSettings.Get.Font;

            this.TxtName.Font = RemoteDBs.Settings.commonSettings.Get.Font;
            this.TxtPass.Font = RemoteDBs.Settings.commonSettings.Get.Font;

            this.TxtName.ForeColor = RemoteDBs.Settings.commonSettings.Get.FontColor;
            this.TxtPass.ForeColor = RemoteDBs.Settings.commonSettings.Get.FontColor;

            this.TxtName.BackColor = RemoteDBs.Settings.commonSettings.Get.ItemColor;
            this.TxtPass.BackColor = RemoteDBs.Settings.commonSettings.Get.ItemColor;

            VisibaleControls(false);
            TxtName.Focus();

            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(10);
                progressBar.Value = i;
            }
            TxtName.Text = localSettings.LstUser.userName;
            //RemoteDBs.Settings.commonSettings.GetSet.Font = new Font("Comic Sans MS", 7f);
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            TxtName.Focus();
        }

        public void LoginCheck()
        {
            string name = TxtName.Text;
            string pass = TxtPass.Text;

            var logInResults = client.LoginCheck(name, pass);

            lblStatus.Text = logInResults.Item2;

            if (logInResults.Item1)
            {
                Core.user = logInResults.Item3;

                Forms.dashboard = new Dashboard();
                if (!Core.user.isAdmin)
                {
                    Forms.dashboard.btnManageData.Enabled = false;
                    Forms.dashboard.btnManageItem.Enabled = false;
                    Forms.dashboard.btnSales.Enabled = false;
                    Forms.dashboard.btnSettings.Enabled = false;
                    Forms.dashboard.btnTransaction.Enabled = false;
                }
                Forms.dashboard.Show();
                localSettings.LstUser = logInResults.Item3;
                Hide();
            }
            else
            {
                lblStatus.ForeColor = Color.PaleVioletRed;
            }
        }

        private void VisibaleControls(bool state)
        {
            label5.Visible = state;
            label6.Visible = state;
            TxtName.Visible = state;
            TxtPass.Visible = state;
            BtnLogin.Visible = state;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (ani)
            {
                ani = false;
                //timer1.Enabled = false;
                // Animator.FormAnimate(this, XanderUI.XUIObjectAnimator.FormAnimation.FadeIn, 1);
                try
                {
                    Animator.StandardAnimate(gb, XanderUI.XUIObjectAnimator.StandardAnimation.SlideLeft, 2);
                    Animator.ColorAnimate(panel2, RemoteDBs.Settings.commonSettings.Get.BackColor, XanderUI.XUIObjectAnimator.ColorAnimation.FillEllipse, true, 1);
                }
                catch
                {

                }
                timer1.Enabled = false;
            }
        }

        private void Buttonlogin_Click(object sender, EventArgs e)
        {
            this.gb.Location = new System.Drawing.Point(30, 5);
            line.Height = buttonlogin.Height;
            line.Top = buttonlogin.Top;
            VisibaleControls(true);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LoginCheck();
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TxtPass.Focus();
        }

        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginCheck();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Core.Shutdown();
            Application.Exit();
        }
    }
}
