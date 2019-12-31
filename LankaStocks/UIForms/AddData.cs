using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LankaStocks.Setting;
using LankaStocks.UserControls;
using static LankaStocks.Core;
using LankaStocks.UIHandle;

namespace LankaStocks.UIForms
{
    public partial class AddData : Form
    {
        public AddData()
        {
            InitializeComponent();
            uiSaveData.Save.Click += Save_Click;
            uiSaveData.RefreshAll.Click += Refresh_Click;
            uiSaveData.Cancel.Click += Cancel_Click;
            TabChanged += Tab_Changed;

            uIPerson = new UIPerson();
            uIVendor = new UIVendor();
            uIUser = new UIUser();
        }
        public AddData(PersonType personType, uint ID = 0)
        {
            InitializeComponent();
            uiSaveData.Save.Click += Save_Click;
            uiSaveData.RefreshAll.Click += Refresh_Click;
            uiSaveData.Cancel.Click += Cancel_Click;
            TabChanged += Tab_Changed;

            if (ID != 0)
            {
                Edit = true;
                uIPerson = new UIPerson();
                uIVendor = new UIVendor();
                uIUser = new UIUser(ID);
            }
            else
            {
                uIPerson = new UIPerson();
                uIVendor = new UIVendor();
                uIUser = new UIUser();
            }

            Current = personType;
        }

        private void Tab_Changed(PersonType args)
        {
            SetUI(args);
        }

        readonly UIPerson uIPerson;
        readonly UIVendor uIVendor;
        readonly UIUser uIUser;
        readonly bool Edit = false;

        public PersonType Current = PersonType.User;
        void SetUI(PersonType type)
        {
            switch (type)
            {
                case PersonType.Vendor:
                    groupBox1.Text = "Vendor's";
                    if (!groupBox1.Controls.Contains(uIVendor))
                    {
                        uIVendor.Dock = DockStyle.Top;
                        groupBox1.Controls.Add(uIVendor);
                    }
                    uIVendor.BringToFront();
                    uIUser.Visible = false;
                    uIPerson.Visible = false;
                    uIVendor.Visible = true;
                    break;
                case PersonType.User:
                    groupBox1.Text = "User's";
                    if (!groupBox1.Controls.Contains(uIUser))
                    {
                        uIUser.Dock = DockStyle.Top;
                        groupBox1.Controls.Add(uIUser);

                    }
                    uIUser.BringToFront();
                    uIVendor.Visible = false;
                    uIPerson.Visible = false;
                    uIUser.Visible = true;
                    break;
                default:
                    groupBox1.Text = "Person's";
                    if (!groupBox1.Controls.Contains(uIPerson))
                    {
                        uIPerson.Dock = DockStyle.Top;
                        groupBox1.Controls.Add(uIPerson);

                    }
                    uIPerson.BringToFront();
                    uIUser.Visible = false;
                    uIVendor.Visible = false;
                    uIPerson.Visible = true;
                    break;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Do You Realy Want To Cancel?", "LankaStocks > Calcel?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK) this.Dispose();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Under Development.", "LankaStocks > Under Development?", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!Edit)
            {
                switch (Current)
                {
                    case PersonType.Vendor:
                        var v = uIVendor.GenerateVendor();
                        client.AddNewVendor(v);
                        break;

                    case PersonType.User:
                        var u = uIUser.GenerateUser();
                        client.AddNewUser(u);
                        break;

                    case PersonType.Person:
                        var p = uIPerson.GeneratePerson();
                        client.AddNewPerson(p);
                        break;

                    default:
                        break;
                }
            }
            else
            {
                switch (Current)
                {
                    case PersonType.Vendor:
                        var v = uIVendor.GenerateVendor();
                        client.SetVendor(v);
                        break;

                    case PersonType.User:
                        var u = uIUser.GenerateUser();
                        client.SetUser(u);
                        break;

                    case PersonType.Person:
                        var p = uIPerson.GeneratePerson();
                        client.SetPerson(p);
                        break;

                    default:
                        break;
                }
            }
            Close();
            //            MessageBox.Show("This Feature Is Under Development.", "LankaStocks > Under Development?", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void AddData_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
            PanelMenu panelMenu = new PanelMenu(panel2, btnhide, 34, panel2.Width);
            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            var handler = TabChanged;
            handler?.Invoke(Current);
        }

        private void BtnPerson_Click(object sender, EventArgs e)
        {
            Current = PersonType.Person;
            var handler = TabChanged;
            handler?.Invoke(Current);
        }

        private void BtnVendor_Click(object sender, EventArgs e)
        {
            Current = PersonType.Vendor;
            var handler = TabChanged;
            handler?.Invoke(Current);
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            Current = PersonType.User;
            var handler = TabChanged;
            handler?.Invoke(Current);
        }
        public event SelectedTabChanged TabChanged;
        public delegate void SelectedTabChanged(PersonType args);
    }
}
