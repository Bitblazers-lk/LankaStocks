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
    public partial class FrmanageItems : Form
    {
        public FrmanageItems()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Forms.addItems = new UIForms.AddItems();
            Forms.addItems.ShowDialog();
        }
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

        private void btnStockIntake_Click(object sender, EventArgs e)
        {
            Forms.itemIntake = new UIForms.ItemIntake();
            Forms.itemIntake.ShowDialog();
        }

        private void FrmanageItems_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);

            ToolBarWidth = panel2.Width;
            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;

            RefDGV("");
            uiExcel1.Set(DGV, new string[] { "Code", "Barcode", "Name", "Buying Price", "Selling Price", "Qty", "Vendor", "Alternative ID" });
            uiExcel1.SetFileName($"Item List {DateTime.Now.Date.ToString("yy-MM-dd")}");
        }

        void RefDGV(uint code)
        {
            var data = new List<DGVMI_Data>();
            foreach (var s in client.ps.Live.Items)
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

        void RefDGV(string barcode)
        {
            var data = new List<DGVMI_Data>();
            foreach (var s in client.ps.Live.Items)
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

        void RefDGV_N(string name)
        {
            var data = new List<DGVMI_Data>();
            foreach (var s in client.ps.Live.Items)
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

        private void TxtCode_TextChanged(object sender, EventArgs e)
        {
            if (uint.TryParse(TxtCode.Text, out uint a)) RefDGV(a);
        }

        private void TxtBarcode_TextChanged(object sender, EventArgs e)
        {
            RefDGV(TxtBarcode.Text);
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            RefDGV_N(TxtName.Text);
        }

        private void BtnRef_Click(object sender, EventArgs e)
        {
            RefDGV("");
        }
    }

    public struct DGVMI_Data
    {
        public uint Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public decimal In_Price { get; set; }
        public decimal Out_Price { get; set; }
        public decimal Qty { get; set; }
        public string Vendor { get; set; }
        public uint Alternative { get; set; }
    }
}
