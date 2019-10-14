using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LankaStocks.Shared;

namespace LankaStocks.UserControls
{
    public partial class UIUser : UserControl
    {
        public UIUser()
        {
            InitializeComponent();
        }

        private void UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Txt(UserName);
            }
        }

        private void UserPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Txt(UserPass);
            }
        }

        private void IsAdmin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Txt(IsAdmin);
            }
        }


        public User GenerateUser()
        {

            if (UserID.Text == "") UserID.Text = "0";
            if (!uint.TryParse(UserID.Text, out uint userID))
            {
                throw new ArgumentException("Value must be a positive integer", "UserID");
            }


            User u = new User
            {
                ID = userID,
                userName = UserName.Text,
                pass = UserPass.Text,
                isAdmin = IsAdmin.SelectedIndex == 1,
                summary = new Transaction() { User = userID, ID = 1, SecondParty = userID, type = Transaction.Types.Summary }
            };

            uiPerson1.ApplyToPerson(u);

            return u;

        }
    }
}
