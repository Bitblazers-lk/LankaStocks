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
    public partial class AddItems : Form
    {
        public AddItems()
        {
            InitializeComponent();

            uiAddItem.ItemName.KeyDown += ItemName_KeyDown;
            uiAddItem.Barcode.KeyDown += Barcode_KeyDown;
            uiAddItem.VendorID.KeyDown += VendorID_KeyDown;
            uiAddItem.InPrice.KeyDown += InPrice_KeyDown;
            uiAddItem.OutPrice.KeyDown += OutPrice_KeyDown;
            uiAddItem.Alternative.KeyDown += Alternative_KeyDown;

            uiSaveData.Save.Click += Save_Click;
            uiSaveData.RefreshAll.Click += Refresh_Click;
            uiSaveData.Cancel.Click += Cancel_Click;
        }

        private void ItemName_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void VendorID_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void InPrice_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OutPrice_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Alternative_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
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

        private void AddItems_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                Settings.LoadCtrlSettings(ctrl);
            }

            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
        }
    }
}
