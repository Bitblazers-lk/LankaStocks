using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            VisibaleControls(false);
            TxtName.Focus();
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            TxtName.Focus();
        }

        public void LoginCheck()
        {
            string name = TxtName.Text;
            string pass = TxtPass.Text;

            //TODO: Change this
            var logInResults = client.LoginCheck(name, pass);

            lblStatus.Text = logInResults.Item2;

            if (logInResults.Item1)
            {
                Hide();
                Forms.dashboard.Show();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ani)
            {
                ani = false;
                //timer1.Enabled = false;
                // Animator.FormAnimate(this, XanderUI.XUIObjectAnimator.FormAnimation.FadeIn, 1);
                try
                {
                    Animator.StandardAnimate(gb, XanderUI.XUIObjectAnimator.StandardAnimation.SlideLeft, 2);
                    Animator.ColorAnimate(panel2, Color.FromArgb(10, 5, 10), XanderUI.XUIObjectAnimator.ColorAnimation.FillEllipse, true, 1);
                }
                catch
                {

                }
                timer1.Enabled = false;
            }         
        }

        private void buttonlogin_Click(object sender, EventArgs e)
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

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
