using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static LankaStocks.Core;
using LankaStocks.KeyInput;
using System.Diagnostics;
using LankaStocks.Shared;
using System.Management;

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

            #region KeyInput Handle
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            _KeyInput = new RawInput(this.Handle, true);

            _KeyInput.KeyPressed += OnKeyPressed;
            #endregion
        }
        uint ItemCode = 0;
        string BeginChar = "i";

        List<string> ItemBarcodes = new List<string>();
        public static Dictionary<uint, float> Cart = new Dictionary<uint, float>();

        private readonly RawInput _KeyInput;

        string Device;
        string Pos_Barcode = localSettings.Data.POSBarcodeID;

        private void OnKeyPressed(object sender, RawInputEventArg e)
        {
            Device = e.KeyPressEvent.DeviceName;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // throw new NotImplementedException();
        }

        #region Search In Store

        private void TxtCode_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtCode.Text))
            {
                Search_Item_Name("");
            }
            else if (uint.TryParse(TxtCode.Text, out uint o)) Search_Item(o);
        }

        private void Search_Item(uint o)
        {
            DGV.DataSource = RepeatedFunctions.Search_Item(o);
            RepeatedFunctions.MarkWarning(DGV.ColumnCount - 1, DGV);
        }
        private void Search_Item_Name(string v)
        {
            DGV.DataSource = RepeatedFunctions.Search_Item_Name(v);
            RepeatedFunctions.MarkWarning(DGV.ColumnCount - 1, DGV);
        }
        private void Search_Item_Barcode(string text)
        {
            DGV.DataSource = RepeatedFunctions.Search_Item_Barcode(text);
            RepeatedFunctions.MarkWarning(DGV.ColumnCount - 1, DGV);
        }
        private void RefStore()
        {
            DGV.DataSource = RepeatedFunctions.RefStore();
            RepeatedFunctions.MarkWarning(DGV.ColumnCount - 1, DGV);
        }

        private void TxtBarcode_TextChanged(object sender, EventArgs e)
        {
            Search_Item_Barcode(TxtBarcode.Text);
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
                RepeatedFunctions.EditCart(Forms.frmEditQty.Code, (float)Forms.frmEditQty.TxtQty.Value, Cart);
                RepeatedFunctions.RefCart(Cart, DGVcart);
                Forms.frmEditQty.Close();
            }
        }

        private void EditQtyOK_Click(object sender, EventArgs e)
        {
            RepeatedFunctions.EditCart(Forms.frmEditQty.Code, (float)Forms.frmEditQty.TxtQty.Value, Cart);
            RepeatedFunctions.RefCart(Cart, DGVcart);
            Forms.frmEditQty.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (DGVcart.CurrentCell != null && uint.TryParse(DGVcart.Rows?[DGVcart.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString(), out uint a))
            {
                RepeatedFunctions.RemoveCart(a, Cart);
                RepeatedFunctions.RefCart(Cart, DGVcart);
            }
            btnEdit.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void DGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGV.CurrentCell != null && DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString() != null)
            {
                if (uint.TryParse(DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString(), out ItemCode))
                {
                    RepeatedFunctions.AddToCart(ItemCode, (float)TxtQty.Value, Cart);
                    RepeatedFunctions.RefCart(Cart, DGVcart);
                }
            }
        }

        #endregion

        private void CodeItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RepeatedFunctions.TxtCode_Handle(CodeItem, TxtQty, Cart, ItemBarcodes, ref ItemCode, Device, Pos_Barcode, BeginChar, DGVcart);
            }
        }
        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RepeatedFunctions.TxtQty_Handle(CodeItem, TxtQty, Cart, ref ItemCode, Device, DGVcart);
            }
        }

        private void BtnRef_Click(object sender, EventArgs e)
        {
            RefStore();
        }

        private void BtnRefund_Click(object sender, EventArgs e)
        {
            Forms.frmRefund = new UIForms.FrmRefund();
            Forms.frmRefund.ShowDialog();
        }

        private void UIMenuA_Load(object sender, EventArgs e)
        {
            labelTotal.Font = new Font(labelTotal.Font.Name.ToString(), labelTotal.Font.Size + 5);
            labelInNO.Font = new Font(labelInNO.Font.Name.ToString(), labelInNO.Font.Size + 2);
            RefStore();
            RepeatedFunctions.CheckBarcodeReader();
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
