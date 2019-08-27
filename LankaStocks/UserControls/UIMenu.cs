using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LankaStocks.Core;

namespace LankaStocks.UserControls
{
    public partial class UIMenu : UserControl
    {
        public UIMenu()
        {
            InitializeComponent();
            int itemC = 0;

            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (itemC < 100)
                {
                    UItem item = new UItem { _Code = s.Key /*Name = s.Key.ToString()*/ };
                    //item.DoubleClick += BtnAddToCart_Click;
                    //item.PB.DoubleClick += BtnAddToCart_Click;
                    //item.btnaddtoc.Click += BtnAddToCart_Click;
                    flowLayoutPanel1.Controls.Add(item);
                }
                itemC++;
                ItemBarcodes.Add(s.Value.Barcode);
            }
            CBItemCount.SelectedIndex = 0;

            DGV.DataSource = RemoteDBs.Live.Items.Get.Values;

            uiBasicSale1.TxtCode.KeyDown += TxtCode_KeyDown;
            uiBasicSale1.TxtQty.KeyDown += TxtQty_KeyDown;
            uiBasicSale1.btnIssue.Click += BtnIssue_Click;
            Forms.frmWaiting = new UIForms.FrmWaiting();
            //Forms.frmWaiting.Show();
        }

        //private void BtnAddToCart_Click(object sender, EventArgs e)
        //{
        //    if (sender is UItem U) MessageBox.Show(U.Name);
        //}

        List<uint> DrawCodes = new List<uint> { 1, 2 }; // Uint Item Codes To Draw In  FlowLayoutPanel

        List<string> ItemBarcodes = new List<string>();

        public static Dictionary<uint, float> Cart = new Dictionary<uint, float>();

        uint ItemCode = 0;
        string BeginChar = "i";

        private void UIMenu_Load(object sender, EventArgs e)
        {
            DrawItems(int.Parse(CBItemCount.Text), (int)TxtPageON.Value);
            foreach (Control s in flowLayoutPanel1.Controls)
            {
                s.Size = new Size(196, 296);
            }
            uiBasicSale1.labelTotal.Font = new Font(uiBasicSale1.labelTotal.Font.Name.ToString(), uiBasicSale1.labelTotal.Font.Size + 5);
            uiBasicSale1.labelInNO.Font = new Font(uiBasicSale1.labelInNO.Font.Name.ToString(), uiBasicSale1.labelInNO.Font.Size + 2);
            DGV.DataSource = Cart;
        }

        private void TxtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (uiBasicSale1.TxtCode.Text.Substring(0, 1) == BeginChar)
                {
                    uint.TryParse(uiBasicSale1.TxtCode.Text.Substring(1), out ItemCode);
                    if (RemoteDBs.Live.Items.Get.ContainsKey(ItemCode)) uiBasicSale1.TxtQty.Focus();
                    else
                    {
                        MessageBox.Show("Item Code Not Found!", "LanakaStocks - Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        uiBasicSale1.TxtCode.Clear();
                    }
                }
                else
                {
                    if (ItemBarcodes.Contains(uiBasicSale1.TxtCode.Text))
                    {
                        uiBasicSale1.TxtQty.Focus();
                        ItemCode = GetUCode(uiBasicSale1.TxtCode.Text);
                    }
                    else
                    {
                        MessageBox.Show("Item Barcode Not Found!", "LanakaStocks - Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        uiBasicSale1.TxtCode.Clear();
                    }
                }
            }
        }

        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddToCart(ItemCode, (float)uiBasicSale1.TxtQty.Value);
                uiBasicSale1.TxtCode.Clear();
                uiBasicSale1.TxtQty.Value = 1;
            }
        }

        private void BtnIssue_Click(object sender, EventArgs e)
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
            List<DGV_Data> Data = new List<DGV_Data>();
            foreach (var s in Cart)
            {
                var i = RemoteDBs.Live.Items.Get[s.Key];
                Data.Add(new DGV_Data { Code = s.Key, Name = i.name, Price = i.outPrice, Qty = s.Value, Total = i.outPrice * (decimal)s.Value });
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

        #region Draw Item's Usercontrols In FlowLayoutPanel
        void DrawItems(int ItemMax, int PageNO)
        {
            for (int i = 0; i <= DrawCodes.Count; i++)
            {
                try
                {
                    if (flowLayoutPanel1.Controls[i] is UItem S)
                    {
                        if (i >= ItemMax * (PageNO - 1) && i < ItemMax * PageNO)
                        {
                            S.Visible = true;
                            S._Code = DrawCodes[i];
                            S.Setdata(DrawCodes[i]);
                        }
                        else S.Visible = false;
                    }
                }
                catch { }
            }
            if (DrawCodes.Count < flowLayoutPanel1.Controls.Count)
            {
                for (int i = DrawCodes.Count; i < flowLayoutPanel1.Controls.Count; i++)
                {
                    if (flowLayoutPanel1.Controls[i] is UItem S)
                    {
                        S.Visible = false;
                    }
                }
            }
        }

        private void CBItemCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawItems(int.Parse(CBItemCount.Text), (int)TxtPageON.Value);
        }
        private void TxtPageON_ValueChanged(object sender, EventArgs e)
        {
            DrawItems(int.Parse(CBItemCount.Text), (int)TxtPageON.Value);
        }
        #endregion

        #region Search Item's In FlowLayoutPanel
        private void TxtCode_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtCode.Text))
            {
                Search_Item_Name("");
            }
            else if (uint.TryParse(TxtCode.Text, out uint o)) Search_Item(o);
        }
        private void TxtBarcode_TextChanged(object sender, EventArgs e)
        {
            Search_Item(TxtBarcode.Text);
        }
        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            Search_Item_Name(TxtName.Text);
        }

        void Search_Item(uint Code)
        {
            DrawCodes.Clear();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (s.Key.ToString().Contains(Code.ToString())) DrawCodes.Add(s.Key);
            }
            DrawItems(int.Parse(CBItemCount.Text), (int)TxtPageON.Value);
        }
        void Search_Item(string BarCode)
        {
            DrawCodes.Clear();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (s.Value.Barcode.ToLower().Contains(BarCode.ToLower())) DrawCodes.Add(s.Key);
            }
            DrawItems(int.Parse(CBItemCount.Text), (int)TxtPageON.Value);
        }
        void Search_Item_Name(string Name)
        {
            DrawCodes.Clear();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (s.Value.name.ToLower().Contains(Name.ToLower())) DrawCodes.Add(s.Key);
            }
            DrawItems(int.Parse(CBItemCount.Text), (int)TxtPageON.Value);
        }
        #endregion

        #region Edit Cart

        private void DGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString() != null)
            {
                btnEdit.Enabled = true;
                btnRemove.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (uint.TryParse(DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString(), out uint a))
            {
                Forms.frmEditQty = new UIForms.FrmEditQty { Code = a };
                Forms.frmEditQty.labelName.Text = $"Name : {RemoteDBs.Live.Items.Get[a].name}\t Code : {a.ToString()}";
                Forms.frmEditQty.btnOK.Click += EditQtyOK_Click;
                Forms.frmEditQty.TxtQty.KeyDown += EditQtyOK_KeyDown;
                Forms.frmEditQty.ShowDialog();
            }
            btnEdit.Enabled = false;
            btnRemove.Enabled = false;
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (uint.TryParse(DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString(), out uint a)) RemoveCart(a);
            btnEdit.Enabled = false;
            btnRemove.Enabled = false;
        }
        #endregion
    }

    public struct DGV_Data
    {
        public uint Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Qty { get; set; }
        public decimal Total { get; set; }
    }
}
