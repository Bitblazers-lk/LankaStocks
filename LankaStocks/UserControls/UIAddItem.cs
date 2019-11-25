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
    public partial class UIAddItem : UserControl
    {
        public UIAddItem()
        {
            InitializeComponent();
            ItemName.Select();
        }

        public bool IsEditMode { get; set; }
        public uint Item_ID { get; set; }

        private void ItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Error.Txt(ItemName)) Barcode.Select();
            }
        }

        private void Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InPrice.Select();
            }
        }

        private void VendorID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Txt(VendorID);
            }
        }

        private void InPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Error.Num(InPrice)) OutPrice.Select();
            }
        }

        private void OutPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Error.Num(OutPrice)) Alternative.Select();
            }
        }

        private void InPrice_TextChanged(object sender, EventArgs e)
        {
            Error.Num(InPrice);
        }

        private void OutPrice_TextChanged(object sender, EventArgs e)
        {
            Error.Num(OutPrice);
        }

        private void VendorID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public List<uint> vendors = new List<uint>();
        public List<uint> Items = new List<uint>();

        private void UIAddItem_Load(object sender, EventArgs e)
        {
            if (!Core.IsInitialized) return;
            RefreshLists();
            if (IsEditMode)
            {
                ItemID.Text = Item_ID.ToString();
                LoadItemDetails(client.ps.Live.Items[Item_ID]);
            }
            else
            {
                ItemID.Text = Item_ID.ToString();
            }
        }

        public void RefreshLists()
        {
            VendorID.Items.Clear();
            Alternative.Items.Clear();

            vendors.Clear();
            Items.Clear();

            foreach (var vend in Core.client.ps.People.Vendors.Values)
            {
                VendorID.Items.Add($"{vend.VendorID}. {vend.name}  - supplies {((vend.supplyingItems.Count == 0) ? "nothing" : (string.Join(",", vend.supplyingItems))) }");
                vendors.Add(vend.ID);
            }

            foreach (var itm in Core.client.ps.Live.Items.Values)
            {
                Alternative.Items.Add($"{itm.itemID}. {itm.name}   available {itm.Quantity} from {itm.vendor}");
                Items.Add(itm.itemID);
            }
        }

        public Item GenerateItem()
        {
            if (ItemID.Text == "") ItemID.Text = "0";
            if (!uint.TryParse(ItemID.Text, out uint itemID))
            {
                throw new ArgumentException("Value must be a positive integer", "ItemID");
            }

            uint vend = VendorID.SelectedIndex == -1 ? 0 : vendors[VendorID.SelectedIndex];
            uint alt = Alternative.SelectedIndex == -1 ? 0 : Items[Alternative.SelectedIndex];

            Item itm = new Item() { itemID = itemID, Barcode = Barcode.Text, inPrice = decimal.Parse(InPrice.Text), name = ItemName.Text, outPrice = decimal.Parse(OutPrice.Text), vendor = vend, Alternative = alt, Quantity = 0 };

            return itm;
        }

        public void LoadItemDetails(Item item)
        {
            ItemID.Text = item.itemID.ToString();
            ItemName.Text = item.name;
            Barcode.Text = item.Barcode;
            InPrice.Text = item.inPrice.ToString("0.00");
            OutPrice.Text = item.outPrice.ToString("0.00");
            if (item.Alternative != 0) Alternative.SelectedIndex = Items.IndexOf(item.Alternative);
            VendorID.SelectedIndex = vendors.IndexOf(item.vendor);
        }
    }
}
