using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LankaStocks.UserControls
{
    public partial class UISelectPerson : UserControl
    {

        private string _PreferedPeopleGroup = "all";
        public string PreferedPeopleGroup
        {
            get { return _PreferedPeopleGroup; }
            set
            {
                if (value == null || value == "") value = "a";

                char def = 'n';
                RBSelOther.Enabled = false;
                RBSelUser.Enabled = false;
                RBSelVendor.Enabled = false;

                foreach (string arg in value.Split(' ', ',', ';', '-'))
                {
                    var v = arg.ToLower();

                    if (v.StartsWith("a"))
                    {
                        _PreferedPeopleGroup = "all";
                        RBSelOther.Enabled = true;
                        RBSelUser.Enabled = true;
                        RBSelVendor.Enabled = true;
                        def = 'u';
                    }
                    else if (v.StartsWith("u"))
                    {
                        def = 'u';
                        _PreferedPeopleGroup = "users";
                        RBSelUser.Enabled = true;
                    }
                    else if (v.StartsWith("o"))
                    {
                        def = 'o';
                        _PreferedPeopleGroup = "others";
                        RBSelOther.Enabled = true;
                    }
                    else if (v.StartsWith("v"))
                    {
                        def = 'v';
                        _PreferedPeopleGroup = "vendors";
                        RBSelVendor.Enabled = true;
                    }

                }

                if (Core.IsInitialized) SelChanged(def, true);



            }
        }

        public bool _ShowRBs = true;
        public bool ShowRadioButtons
        {
            get { return _ShowRBs; }
            set
            {
                _ShowRBs = value;
                if (value)
                {
                    RBSelOther.Visible = true; RBSelUser.Visible = true; RBSelVendor.Visible = true;
                }
                else
                {
                    RBSelOther.Visible = false; RBSelUser.Visible = false; RBSelVendor.Visible = false;
                }
            }
        }




        public UISelectPerson()
        {
            InitializeComponent();
            //PreferedPeopleGroup = "a";
        }

        private void RBSelVendor_CheckedChanged(object sender, EventArgs e)
        {
            if (Core.IsInitialized && ((RadioButton)sender).Checked) SelChanged('v', false);
        }

        private void RBSelUser_CheckedChanged(object sender, EventArgs e)
        {
            if (Core.IsInitialized && ((RadioButton)sender).Checked) SelChanged('u', false);
        }

        private void RBSelOther_CheckedChanged(object sender, EventArgs e)
        {
            if (Core.IsInitialized && ((RadioButton)sender).Checked) SelChanged('o', false);
        }

        public List<Person> People = new List<Person>();
        public char Selected = 'n';

        /// <summary>
        /// </summary>
        /// <param name="sel"> v|u|o </param>
        public void SelChanged(char sel, bool check)
        {
            if (!Core.IsInitialized) return;

            if (check)
            {
                RBSelOther.Checked = false;
                RBSelUser.Checked = false;
                RBSelVendor.Checked = false;
            }

            Cmb.Items.Clear();
            //People.Clear();

            switch (sel)
            {
                case 'v':
                    var Vends = Core.client.ps.People.Vendors.Values;
                    People = new List<Person>(Vends.Count);

                    foreach (var p in Vends)
                    {
                        Cmb.Items.Add($"{p.VendorID}. {p.name} - {p.details}  - supplies {((p.supplyingItems == null) ? "nothing" : (string.Join(",", p.supplyingItems))) }");
                        People.Add(p);
                    }
                    if (check) RBSelVendor.Checked = true;
                    break;

                case 'u':
                    var users = Core.client.ps.People.Users.Values;
                    People = new List<Person>(users.Count);

                    foreach (var u in users)
                    {
                        Cmb.Items.Add($"{u.ID}. {u.userName}  - {u.name}  {(u.isAdmin ? "(Admin)" : "")}");
                        People.Add(u);
                    }
                    if (check) RBSelUser.Checked = true;
                    break;

                case 'o':
                    var others = Core.client.ps.People.OtherPeople.Values;
                    People = new List<Person>(others.Count);

                    foreach (var o in others)
                    {
                        Cmb.Items.Add($"{o.ID}. {o.name}  - {o.details}");
                        People.Add(o);
                    }
                    if (check) RBSelOther.Checked = true;
                    break;

                default:
                    People = new List<Person>();
                    break;
            }

        }

        public Person GetPerson()
        {

            if (Cmb.SelectedIndex >= 0)
            {
                try
                {
                    return People[Cmb.SelectedIndex];
                }
                catch (Exception)
                {
                    return null;
                }

            }
            else
            {
                return null;
            }

        }

        public (uint ID, char type) GetPersonTypeAndID()
        {
            switch (Selected)
            {
                case 'v':
                    if (Cmb.SelectedIndex >= 0)
                    {
                        try
                        {
                            return (((Vendor)People[Cmb.SelectedIndex]).VendorID, Selected);
                        }
                        catch (Exception)
                        {
                            return (0, Selected);
                        }
                    }
                    else
                    {
                        return (0, Selected);
                    }

                case 'u':
                    if (Cmb.SelectedIndex >= 0)
                    {
                        try
                        {
                            return (((User)People[Cmb.SelectedIndex]).ID, Selected);
                        }
                        catch (Exception)
                        {
                            return (0, Selected);
                        }
                    }
                    else
                    {
                        return (0, Selected);
                    }


                case 'o':
                    if (Cmb.SelectedIndex >= 0)
                    {
                        try
                        {
                            return (((Person)People[Cmb.SelectedIndex]).ID, Selected);
                        }
                        catch (Exception)
                        {
                            return (0, Selected);
                        }
                    }
                    else
                    {
                        return (0, Selected);
                    }



                default:
                    return (0, 'n');
            }

        }

    }
}
