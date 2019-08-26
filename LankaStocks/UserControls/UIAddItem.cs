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
    public partial class UIAddItem : UserControl
    {
        public UIAddItem()
        {
            InitializeComponent();
        }

        private void ItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Txt(ItemName);
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
                Error.Num(InPrice);
            }
        }

        private void OutPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Num(OutPrice);
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

            VendorID.Items.Clear();
            Core.client.vendors = Core.RemoteDBs.People.Vendors.Get;

            Alternative.Items.Clear();
            Core.client.Items = Core.RemoteDBs.Live.Items.Get;

            vendors.Clear();
            Items.Clear();


            foreach (var vend in Core.client.vendors.Values)
            {
                VendorID.Items.Add($"{vend.VendorID}. {vend.name}  - supplies {((vend.supplyingItems == null) ? "nothing" : (string.Join(",", vend.supplyingItems))) }");
                vendors.Add(vend.ID);
            }



            foreach (var itm in Core.client.Items.Values)
            {
                Alternative.Items.Add($"{itm.itemID}. {itm.name}   available {itm.Quantity} from {itm.vendors}");
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

            Item itm = new Item() { itemID = itemID, Barcode = Barcode.Text, inPrice = decimal.Parse(InPrice.Text), name = ItemName.Text, outPrice = decimal.Parse(OutPrice.Text), vendors = new List<uint>() { vend }, Alternative = alt, Quantity = 0 };

            return itm;
        }
    }
}
