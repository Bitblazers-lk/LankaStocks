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
using static LankaStocks.Core;

namespace LankaStocks.UserControls
{
    public partial class UIUser : UserControl
    {
        public UIUser()
        {
            InitializeComponent();
            uiPerson1.PersonID.ReadOnly = false;

        }

        public UIUser(uint UID)
        {
            InitializeComponent();
            EditMode = true;
            User_ID = UID;
            uiPerson1.PersonID.ReadOnly = true;

            LoadUserDetails(RemoteDBs.People.Users.Get[User_ID]);
        }

        public bool EditMode { get; set; }
        public uint User_ID { get; set; }

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

        public void LoadUserDetails(User user)
        {
            uiPerson1.PersonID.ReadOnly = true;
            uiPerson1.PersonID.Text = user.ID.ToString();
            uiPerson1.PersonName.Text = user.name;
            uiPerson1.Details.Text = user.details;
            uiPerson1.ContactInfo.Text = user.contactInfo;
            UserID.Text = user.ID.ToString();
            UserName.Text = user.userName;
            UserPass.Text = user.pass;
            if (user.isAdmin) IsAdmin.SelectedIndex = 1; else IsAdmin.SelectedIndex = 0;
        }
    }
}
