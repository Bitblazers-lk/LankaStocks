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

            uIPerson.Visible = true;
            uIVendor.Visible = false;
            uIUser.Visible = false;
            uIVendor.Dock = DockStyle.None;
            uIUser.Dock = DockStyle.None;
            uIPerson.Dock = DockStyle.Top;
            panel3.Controls.Add(uIPerson);
        }


        public char selUI = 'n';

        UIPerson uIPerson = new UIPerson();
        UIVendor uIVendor = new UIVendor();
        UIUser uIUser = new UIUser();

        int ToolBarWidth;

        private void btnhide_Click(object sender, EventArgs e)
        {
            if (panel2.Width == ToolBarWidth)
            {
                panel2.Width = 35;
            }
            else if (panel2.Width == 35)
            {
                panel2.Width = ToolBarWidth;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            switch (selUI)
            {
                case 'v':
                    var v = uIVendor.GenerateVendor();
                    client.AddNewVendor(v);
                    break;

                case 'u':
                    var u = uIUser.GenerateUser();
                    client.AddNewUser(u);
                    break;

                case 'p':
                    var p = uIPerson.GeneratePerson();
                    client.AddNewPerson(p);
                    break;

                default:
                    break;
            }
            Close();
            //throw new NotImplementedException();
        }

        private void AddData_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
            ToolBarWidth = panel2.Width;
            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            if (panel3.Controls.Contains(uIPerson))
            {
                uIPerson.Visible = true;

                uIVendor.Visible = false;
                uIUser.Visible = false;

                uIVendor.Dock = DockStyle.None;
                uIUser.Dock = DockStyle.None;
                uIPerson.Dock = DockStyle.Top;
            }
            else
            {
                uIPerson.Dock = DockStyle.Top;
                panel3.Controls.Add(uIPerson);
            }
            selUI = 'p';
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            if (panel3.Controls.Contains(uIVendor))
            {
                uIVendor.Visible = true;

                uIPerson.Visible = false;
                uIUser.Visible = false;

                uIPerson.Dock = DockStyle.None;
                uIUser.Dock = DockStyle.None;
                uIVendor.Dock = DockStyle.Top;
            }
            else
            {
                uIVendor.Dock = DockStyle.Top;
                panel3.Controls.Add(uIVendor);
            }
            selUI = 'v';
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (panel3.Controls.Contains(uIUser))
            {
                uIUser.Visible = true;

                uIVendor.Visible = false;
                uIPerson.Visible = false;

                uIPerson.Dock = DockStyle.None;
                uIVendor.Dock = DockStyle.None;
                uIUser.Dock = DockStyle.Top;
            }
            else
            {
                uIUser.Dock = DockStyle.Top;
                panel3.Controls.Add(uIUser);
            }
            selUI = 'u';
        }

        private void UiSaveData_Load(object sender, EventArgs e)
        {

        }
    }
}
