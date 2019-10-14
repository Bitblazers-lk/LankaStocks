using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LankaStocks.Core;
using LankaStocks.Shared;

namespace LankaStocks.UIForms
{
    public partial class FrmItemView : Form
    {
        public FrmItemView()
        {
            InitializeComponent();
        }

        public FrmItemView(Dictionary<uint, Item> Data, Control Para)
        {
            InitializeComponent();
            Items = Data;
            ParentCtrl = Para;
        }

        FormBorderStyle style;
        Control ParentCtrl;
        ContextMenuStrip cmDgv = new ContextMenuStrip();

        void RefDGV(uint code, Dictionary<uint, Item> sample)
        {
            var data = new List<DGVMI_Data>();
            foreach (var s in sample)
            {
                if (s.Key.ToString().ToLower().Contains(code.ToString().ToLower()))
                {
                    string ven = "";
                    if (s.Value.vendors.Count > 1) ven = $"Count : {s.Value.vendors.Count}";
                    //else ven = client.ps.People.Vendors[s.Value.vendors[0]].name;
                    data.Add(new DGVMI_Data { Code = s.Value.itemID, Barcode = s.Value.Barcode, Name = s.Value.name, In_Price = s.Value.inPrice, Out_Price = s.Value.outPrice, Qty = s.Value.Quantity, Alternative = s.Value.Alternative, Vendor = ven });
                }
            }
            DGV.DataSource = data;
        }

        void RefDGV(string barcode, Dictionary<uint, Item> sample)
        {
            var data = new List<DGVMI_Data>();
            foreach (var s in sample)
            {
                if (s.Value.Barcode.ToLower().Contains(barcode.ToLower()))
                {
                    string ven = "";
                    if (s.Value.vendors.Count > 1) ven = $"Count : {s.Value.vendors.Count}";
                    //else ven = client.ps.People.Vendors[s.Value.vendors[0]].name;
                    data.Add(new DGVMI_Data { Code = s.Value.itemID, Barcode = s.Value.Barcode, Name = s.Value.name, In_Price = s.Value.inPrice, Out_Price = s.Value.outPrice, Qty = s.Value.Quantity, Alternative = s.Value.Alternative, Vendor = ven });
                }
            }
            DGV.DataSource = data;
        }

        void RefDGV_N(string name, Dictionary<uint, Item> sample)
        {
            var data = new List<DGVMI_Data>();
            foreach (var s in sample)
            {
                if (s.Value.name.ToLower().Contains(name.ToLower()))
                {
                    string ven = "";
                    if (s.Value.vendors.Count > 1) ven = $"Count : {s.Value.vendors.Count}";
                    //else ven = client.ps.People.Vendors[s.Value.vendors[0]].name;
                    data.Add(new DGVMI_Data { Code = s.Value.itemID, Barcode = s.Value.Barcode, Name = s.Value.name, In_Price = s.Value.inPrice, Out_Price = s.Value.outPrice, Qty = s.Value.Quantity, Alternative = s.Value.Alternative, Vendor = ven });
                }
            }
            DGV.DataSource = data;
        }

        public Dictionary<uint, Item> Items = new Dictionary<uint, Item>();

        void Search(uint Code, string Barcode, string Name)
        {
            SearchItem Fill = new SearchItem();
            Item Temp = new Item
            {
                name = Name,
                itemID = Code,
                Barcode = Barcode
            };
            //Fill.Find(Items, Temp);
        }

        private void TxtS1_TextChanged(object sender, EventArgs e)
        {
            if (uint.TryParse(TxtS1.Text, out uint a))
            {
                RefDGV(a, Items);
            }
        }

        private void TxtS2_TextChanged(object sender, EventArgs e)
        {
            RefDGV(TxtS2.Text, Items);
        }

        private void TxtS3_TextChanged(object sender, EventArgs e)
        {
            RefDGV_N(TxtS3.Text, Items);
        }

        private void BtnRef_Click(object sender, EventArgs e)
        {
            RefDGV("", Items);
        }

        private void DGV_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.ContextMenuStrip != cmDgv) DGV.ContextMenuStrip = cmDgv;
        }

        private void DGV_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.ContextMenuStrip != null) DGV.ContextMenuStrip = null;
        }

        private void FrmItemView_Load(object sender, EventArgs e)
        {
            //Setting.Settings.LoadCtrlSettings(this);
            RefDGV("", Items);
            uiExcel1.Set(DGV, new string[] { "Code", "Barcode", "Name", "Buying Price", "Selling Price", "Qty", "Vendor", "Alternative ID" });
            uiExcel1.SetFileName($"Item List {DateTime.Now.Date.ToString("yy-MM-dd")}");

            cmDgv.Items.Add("Refresh", Properties.Resources.recurring_appointment_24px, new EventHandler(BtnRef_Click));
            cmDgv.Items.Add("Edit Item Details", Properties.Resources.edit_24px, new EventHandler(Edit_Details_Click));
            cmDgv.Items.Add("Remove Item", Properties.Resources.delete_sign_24px, new EventHandler(Remove_Details_Click));
            cmDgv.Items.Add("See Item History", Properties.Resources.menu_24px, new EventHandler(Item_His_Click));
            cmDgv.BackColor = Color.LightGray;
            style = this.FormBorderStyle;
        }

        private void Edit_Details_Click(object sender, EventArgs e)
        {
            if (!ParentCtrl.Controls.Contains(Forms.addItems))
            {
                Forms.addItems = new AddItems();
                FormHandle form1 = new FormHandle();
                form1.OpenForm(ParentCtrl, Forms.addItems, FormBorderStyle = FormBorderStyle.Fixed3D, DockStyle.Top);
            }
        }

        private void Remove_Details_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Under Development.", "LankaStocks > Under Development?", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void Item_His_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Under Development.", "LankaStocks > Under Development?", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void FrmItemView_StyleChanged(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != style) this.FormBorderStyle = style;
        }
    }
    public abstract class ItemFilter<T>
    {
        public abstract IEnumerable<T> Find(IEnumerable<T> ts, T sample);
    }

    public class SearchItem : ItemFilter<Item>
    {
        public override IEnumerable<Item> Find(IEnumerable<Item> ts, Item sample)
        {
            bool NameOK = sample.name != null;
            bool BarcodeOK = sample.Barcode != null;
            bool CodeOK = sample.itemID > 0;

            foreach (var sch in ts)
            {
                if (CodeOK)
                {
                    if (sch.itemID.ToString().Contains(sample.itemID.ToString())) yield return sch;
                }
                else if (BarcodeOK)
                {
                    if (sch.Barcode.ToLower().Contains(sample.Barcode.ToLower())) yield return sch;
                }
                else if (NameOK)
                {
                    if (sch.name.ToLower().Contains(sample.name.ToLower())) yield return sch;
                }
            }
        }
    }
}
