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
    public partial class UIPerson : UserControl
    {
        public UIPerson()
        {
            InitializeComponent();
        }

        private void PersonName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Txt(PersonName);
            }
        }

        private void Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Txt(Details);
            }
        }

        private void ContactInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Txt(ContactInfo);
            }
        }

        public Person GeneratePerson()
        {
            Person p = new Person();
            ApplyToPerson(p);

            return p;
        }

        public void ApplyToPerson(Person p)
        {
            if (PersonID.Text == "") PersonID.Text = "0";
            if (!uint.TryParse(PersonID.Text, out uint personID))
            {
                throw new ArgumentException("Value must be a positive integer", "PersonID");
            }

            p.ID = personID;
            p.name = PersonName.Text;
            p.contactInfo = ContactInfo.Text;
            p.details = Details.Text;
            p.summary = new Transaction();
        }
    }
}
