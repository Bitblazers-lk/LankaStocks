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
    public partial class UIMenuA : UserControl
    {
        public UIMenuA()
        {
            InitializeComponent();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                ItemBarcodes.Add(s.Value.Barcode);
            }           
        }
        uint ItemCode = 0;
        string BeginChar = "i";

        List<string> ItemBarcodes = new List<string>();
        public static Dictionary<uint, float> Cart = new Dictionary<uint, float>();

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
            DGVcart.DataSource = Data;
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

        #region Search In Store

        void RefStore()
        {
            List<DGV_Data> Data = new List<DGV_Data>();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                Data.Add(new DGV_Data { Code = s.Key, Barcode = s.Value.Barcode, Name = s.Value.name, Price = s.Value.outPrice, Qty = s.Value.Quantity, });
            }
            DGV.DataSource = Data;
            MarkWarning();
        }

        private void MarkWarning()
        {
            float min = RemoteDBs.Settings.commonSettings.Get.WarnWhen;

            for (int a = 0; a < DGV.RowCount; a++)
            {
                for (int i = 0; i < DGV.ColumnCount; i++)
                {
                    if (i == DGV.ColumnCount - 1 && float.TryParse(DGV.Rows[a].Cells[i].Value.ToString(), out float c) && c <= min)
                    {
                        for (int x = 0; x < DGV.ColumnCount; x++)
                        {
                            DGV.Rows[a].Cells[x].Style.ForeColor = Color.Red;
                            //DGV.Rows[a].Cells[i].Style.BackColor = Color.Red;
                        }
                    }
                }
            }
        }

        void Search_Item(uint Code)
        {
            List<DGV_Data> Data = new List<DGV_Data>();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (s.Key.ToString().Contains(Code.ToString()))
                    Data.Add(new DGV_Data { Code = s.Key, Barcode = s.Value.Barcode, Name = s.Value.name, Price = s.Value.outPrice, Qty = s.Value.Quantity, });
            }
            DGV.DataSource = Data;
            MarkWarning();
        }
        void Search_Item(string Barcode)
        {
            List<DGV_Data> Data = new List<DGV_Data>();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (s.Value.Barcode.ToLower().Contains(Barcode.ToLower()))
                    Data.Add(new DGV_Data { Code = s.Key, Barcode = s.Value.Barcode, Name = s.Value.name, Price = s.Value.outPrice, Qty = s.Value.Quantity, });
            }
            DGV.DataSource = Data;
            MarkWarning();
        }
        void Search_Item_Name(string Name)
        {
            List<DGV_Data> Data = new List<DGV_Data>();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (s.Value.name.ToLower().Contains(Name.ToLower()))
                    Data.Add(new DGV_Data { Code = s.Key, Barcode = s.Value.Barcode, Name = s.Value.name, Price = s.Value.outPrice, Qty = s.Value.Quantity, });
            }
            DGV.DataSource = Data;
            MarkWarning();
        }

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
        #endregion

        #region Cart Handle
        private void DGVcart_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGVcart.CurrentCell != null && DGVcart.Rows?[DGVcart.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString() != null)
            {
                btnEdit.Enabled = true;
                btnRemove.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (DGVcart.CurrentCell != null && uint.TryParse(DGVcart.Rows?[DGVcart.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString(), out uint a))
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
            if (DGVcart.CurrentCell != null && uint.TryParse(DGVcart.Rows?[DGVcart.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString(), out uint a)) RemoveCart(a);
            btnEdit.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void DGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGV.CurrentCell != null && DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString() != null)
            {
                if (uint.TryParse(DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString(), out ItemCode))
                    AddToCart(ItemCode, (float)TxtQty.Value);
            }
        }

        #endregion

        private void CodeItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CodeItem.Text.Substring(0, 1) == BeginChar)
                {
                    if (uint.TryParse(CodeItem.Text.Substring(1), out ItemCode) && RemoteDBs.Live.Items.Get.ContainsKey(ItemCode)) TxtQty.Focus();
                    else
                    {
                        MessageBox.Show("Item Code Not Found!", "LanakaStocks - Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CodeItem.Clear();
                    }
                }
                else
                {
                    if (ItemBarcodes.Contains(CodeItem.Text))
                    {
                        TxtQty.Focus();
                        ItemCode = GetUCode(CodeItem.Text);
                    }
                    else
                    {
                        MessageBox.Show("Item Barcode Not Found!", "LanakaStocks - Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CodeItem.Clear();
                    }
                }
            }
        }
        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddToCart(ItemCode, (float)TxtQty.Value);
                CodeItem.Clear();
                TxtQty.Value = 1;
            }
        }

        private void BtnRef_Click(object sender, EventArgs e)
        {
            RefStore();
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            Forms.frmRefund = new UIForms.FrmRefund();
            Forms.frmRefund.ShowDialog();
        }

        private void UIMenuA_Load(object sender, EventArgs e)
        {
            labelTotal.Font = new Font(labelTotal.Font.Name.ToString(), labelTotal.Font.Size + 5);
            labelInNO.Font = new Font(labelInNO.Font.Name.ToString(), labelInNO.Font.Size + 2);
            RefStore();
        }
    }

    public struct DGV_Data
    {
        public uint Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Qty { get; set; }
    }
}
