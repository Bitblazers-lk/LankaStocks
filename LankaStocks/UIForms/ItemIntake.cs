using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LankaStocks.UIForms
{
    public partial class ItemIntake : Form
    {
        public ItemIntake()
        {
            InitializeComponent();

            uiStockIntake.VendorID.KeyDown += VendorID_KeyDown;
            uiStockIntake.ItemID.KeyDown += ItemID_KeyDown;
            uiStockIntake.Qty.KeyDown += Qty_KeyDown;
            uiStockIntake.uiTransaction.Paid.KeyDown += Paid_KeyDown;
            uiStockIntake.uiTransaction.Secondparty.KeyDown += Secondparty_KeyDown;
            uiStockIntake.uiTransaction.Confirm.KeyDown += Confirm_KeyDown;
            uiStockIntake.uiTransaction.Note.KeyDown += Note_KeyDown;
            uiStockIntake.uiTransaction.OfficePersonID.KeyDown += OfficePersonID_KeyDown;

            uiSaveData.Save.Click += Save_Click;
            uiSaveData.RefreshAll.Click += Refresh_Click;
            uiSaveData.Cancel.Click += Cancel_Click;
        }

        private void VendorID_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void ItemID_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void Qty_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void Paid_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void Secondparty_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void Confirm_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void Note_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void OfficePersonID_KeyDown(object sender, KeyEventArgs e)
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
    }
}
