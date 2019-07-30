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

namespace LankaStocks
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

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

            foreach (var usr in People.Users.Values)
            {
                if (usr.userName == name)
                {
                    if (usr.pass == pass)
                    {
                        //Forms.dashboard.Hide();
                        Forms.dashboard = new Dashboard();
                        Forms.dashboard.Show();
                        lblStatus.Text = "Wellcome";
                        this.Hide();
                        return;
                    }
                    else
                    {
                        lblStatus.Text = "Wrong password";
                        return;
                    }
                }
                else
                {
                    lblStatus.Text = "Wrong user name or password";
                }
            }
        }



        private void VisibaleControls(bool state)
        {
            label3.Visible = state;
            label7.Visible = state;
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
                    //Animator.StandardAnimate(gb, XanderUI.XUIObjectAnimator.StandardAnimation.SlideLeft, 2);
                    Animator.ColorAnimate(panel2, Color.FromArgb(60, 60, 60), XanderUI.XUIObjectAnimator.ColorAnimation.FillSquare, true, 1);
                }
                catch
                {

                }
                timer1.Enabled = false;
            }
            VisibaleControls(true);
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            this.gb.Location = new System.Drawing.Point(176, 19);
            line.Height = buttonlogin.Height;
            line.Top = buttonlogin.Top;
            VisibaleControls(true);
        }



        private void BtnLogin_Click_1(object sender, EventArgs e)
        {
            LoginCheck();
        }

        private void TxtName_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TxtPass.Focus();
        }

        private void TxtPass_KeyDown_1(object sender, KeyEventArgs e)
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
