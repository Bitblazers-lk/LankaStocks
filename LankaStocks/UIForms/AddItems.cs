using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LankaStocks;
using LankaStocks.Setting;
using LankaStocks.Shared;
using static LankaStocks.Core;

namespace LankaStocks.UIForms
{
    public partial class AddItems : Form
    {
        public AddItems()
        {
            InitializeComponent();
            uiAddItem.IsEditMode = false;
            //uiAddItem.ItemName.KeyDown += ItemName_KeyDown;
            //uiAddItem.Barcode.KeyDown += Barcode_KeyDown;
            //uiAddItem.VendorID.KeyDown += VendorID_KeyDown;
            //uiAddItem.InPrice.KeyDown += InPrice_KeyDown;
            //uiAddItem.OutPrice.KeyDown += OutPrice_KeyDown;
            //uiAddItem.Alternative.KeyDown += Alternative_KeyDown;

            uiSaveData.Save.Click += Save_Click;
            uiSaveData.RefreshAll.Click += Refresh_Click;
            uiSaveData.Cancel.Click += Cancel_Click;
        }

        public AddItems(uint ItemID)
        {
            InitializeComponent();
            uiAddItem.IsEditMode = true;
            uiAddItem.Item_ID = ItemID;
            //uiAddItem.ItemName.KeyDown += ItemName_KeyDown;
            //uiAddItem.Barcode.KeyDown += Barcode_KeyDown;
            //uiAddItem.VendorID.KeyDown += VendorID_KeyDown;
            //uiAddItem.InPrice.KeyDown += InPrice_KeyDown;
            //uiAddItem.OutPrice.KeyDown += OutPrice_KeyDown;
            //uiAddItem.Alternative.KeyDown += Alternative_KeyDown;

            uiSaveData.Save.Click += Save_Click;
            uiSaveData.RefreshAll.Click += Refresh_Click;
            uiSaveData.Cancel.Click += Cancel_Click;
        }

        //private void ItemName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        Error.Txt(uiAddItem.ItemName);
        //    }
        //}

        //private void Barcode_KeyDown(object sender, KeyEventArgs e)
        //{

        //}

        //private void VendorID_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        Error.Txt(uiAddItem.VendorID);
        //    }
        //}

        //private void InPrice_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        Error.Num(uiAddItem.InPrice);
        //    }
        //}

        //private void OutPrice_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        Error.Num(uiAddItem.OutPrice);
        //    }
        //}

        //private void Alternative_KeyDown(object sender, KeyEventArgs e)
        //{

        //}

        private void Cancel_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Do You Realy Want To Cancel?", "LankaStocks > Calcel?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK) this.Dispose();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            uiAddItem.RefreshLists();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!uiAddItem.IsEditMode)
            {
                var itm = uiAddItem.GenerateItem();
                var resp = client.AddItem(itm);

                if (resp.result == (byte)Networking.Response.Result.ok)
                {
                    Log($"Done Add Item... Item ID : {itm.itemID}, Item Name : {itm.name}\n     By {user.userName}");
                    MessageBox.Show($"Done Add Item!\nItem ID : {itm.itemID}\nItem Name : {itm.name}\nItem Price : {itm.outPrice}", "LankaStocks > Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string s = $"Failed To Add Item! {((Networking.Response.Result)resp.result).ToString()} - {resp.msg}";
                    Log(s);
                    MessageBox.Show(s, "LanakaStocks > Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var itm = uiAddItem.GenerateItem();
                var resp = client.EditItem(itm);

                if (resp.result == (byte)Networking.Response.Result.ok)
                {
                    Log($"Done Editing Item... Item ID : {itm.itemID}, Item Name : {itm.name}\n    By {user.userName}");
                    MessageBox.Show($"Done Editing Item Details!\nItem ID : {itm.itemID}\nItem Name : {itm.name}\nItem Price : {itm.outPrice}", "LankaStocks > Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string s = $"Failed To Edit Item Details! {((Networking.Response.Result)resp.result).ToString()} - {resp.msg}";
                    Log(s);
                    MessageBox.Show(s, "LanakaStocks > Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Close();
        }

        private void AddItems_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
        }
    }
}
