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
        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            if (panel2.Width == 200)
            {
                panel2.Width = 40;
            }
            else if (panel2.Width == 40)
            {
                panel2.Width = 200;
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
            throw new NotImplementedException();
        }

        private void AddData_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                Settings.LoadCtrlSettings(ctrl);
            }

            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
        }
    }
}
