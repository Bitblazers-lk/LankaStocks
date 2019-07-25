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

        private void Login_Load(object sender, EventArgs e)
        {
            TxtName.Focus();
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            TxtName.Focus();
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TxtPass.Focus();
        }

        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoginCheck();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LoginCheck();
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
                        this.Hide();
                        lblStatus.Text = "Wellcome";
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

    }
}
