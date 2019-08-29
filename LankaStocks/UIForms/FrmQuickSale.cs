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
    public partial class FrmQuickSale : Form
    {
        public FrmQuickSale()
        {
            InitializeComponent();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                ItemBarcodes.Add(s.Value.Barcode);
            }
            cm.Items.Add("Edit", new Bitmap(10, 10), new EventHandler(Edit_Click));
            cm.Items.Add("Remove", new Bitmap(10, 10), new EventHandler(Remove_Click));
            DGV.ContextMenuStrip = cm;
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (DGV.CurrentCell != null && uint.TryParse(DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString(), out uint a))
            {
                Forms.frmEditQty = new UIForms.FrmEditQty { Code = a };
                Forms.frmEditQty.labelName.Text = $"Name : {RemoteDBs.Live.Items.Get[a].name}\t Code : {a.ToString()}";
                Forms.frmEditQty.btnOK.Click += EditQtyOK_Click;
                Forms.frmEditQty.TxtQty.KeyDown += EditQtyOK_KeyDown;
                Forms.frmEditQty.ShowDialog();
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (DGV.CurrentCell != null && uint.TryParse(DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString(), out uint a)) RemoveCart(a);
        }

        private void EditQtyOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditCart(Forms.frmEditQty.Code, (float)Forms.frmEditQty.TxtQty.Value);
                Forms.frmEditQty.Close();
            }
        }

        private void EditQtyOK_Click(object sender, EventArgs e)
        {
            EditCart(Forms.frmEditQty.Code, (float)Forms.frmEditQty.TxtQty.Value);
            Forms.frmEditQty.Close();
        }

        int ToolBarWidth;
        uint ItemCode = 0;
        string BeginChar = "i";
        List<string> ItemBarcodes = new List<string>();
        public static Dictionary<uint, float> Cart = new Dictionary<uint, float>();

        ContextMenuStrip cm = new ContextMenuStrip();

        private void btnhide_Click(object sender, EventArgs e)
        {
            if (panel1.Width == ToolBarWidth)
            {
                panel1.Width = 35;
            }
            else if (panel1.Width == 35)
            {
                panel1.Width = ToolBarWidth;
            }
        }

        private void btnfund_Click(object sender, EventArgs e)
        {
            Forms.frmRefund = new FrmRefund();
            Forms.frmRefund.ShowDialog();
        }

        private void TxtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtCode.Text.Substring(0, 1) == BeginChar)
                {
                    if (uint.TryParse(TxtCode.Text.Substring(1), out ItemCode) && RemoteDBs.Live.Items.Get.ContainsKey(ItemCode)) TxtQty.Focus();
                    else
                    {
                        MessageBox.Show("Item Code Not Found!", "LanakaStocks - Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TxtCode.Clear();
                    }
                }
                else
                {
                    if (ItemBarcodes.Contains(TxtCode.Text))
                    {
                        TxtQty.Focus();
                        ItemCode = GetUCode(TxtCode.Text);
                    }
                    else
                    {
                        MessageBox.Show("Item Barcode Not Found!", "LanakaStocks - Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TxtCode.Clear();
                    }
                }
            }
        }

        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddToCart(ItemCode, (float)TxtQty.Value);
                TxtCode.Clear();
                TxtQty.Value = 1;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

        }

        #region Cart
        public void AddToCart(uint code, float qty)
        {
            if (Cart.ContainsKey(code))
            {
                Cart[code] += qty;
            }
            else Cart.Add(code, qty);
            RefCart(Cart);
        }
        public void EditCart(uint code, float Newqty)
        {
            if (Cart.ContainsKey(code))
            {
                Cart[code] = Newqty;
            }
            RefCart(Cart);
        }
        public void RemoveCart(uint code)
        {
            if (Cart.ContainsKey(code))
            {
                Cart.Remove(code);
            }
            RefCart(Cart);
        }
        void RefCart(Dictionary<uint, float> Cart)
        {
            List<DGVcart_Data> Data = new List<DGVcart_Data>();
            foreach (var s in Cart)
            {
                var i = RemoteDBs.Live.Items.Get[s.Key];
                Data.Add(new DGVcart_Data { Code = s.Key, Name = i.name, Price = i.outPrice, Qty = s.Value, Total = i.outPrice * (decimal)s.Value });
            }
            DGV.DataSource = Data;
        }
        uint GetUCode(string Barcode)
        {
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (s.Value.Barcode == Barcode) return s.Key;
            }
            return 0;
        }
        #endregion

        private void FrmQuickSale_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
            ToolBarWidth = panel1.Width;

            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel3.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
        }
    }
}
