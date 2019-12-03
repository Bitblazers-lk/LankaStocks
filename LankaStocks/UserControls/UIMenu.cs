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
using LankaStocks.KeyInput;
using System.Diagnostics;
using LankaStocks.Shared;
using System.Management;

namespace LankaStocks.UserControls
{
    public partial class UIMenu : UserControl
    {
        public UIMenu()
        {
            InitializeComponent();
            int itemC = 0;

            foreach (var s in client.ps.Live.Items)
            {
                if (itemC < 100)
                {
                    UItem item = new UItem { _Code = s.Key /*Name = s.Key.ToString()*/ };
                    DrawCodes.Add(s.Key);
                    item.CartItemSelected += CartItem_Selected;
                    //item.DoubleClick += BtnAddToCart_Click;
                    //item.PB.DoubleClick += BtnAddToCart_Click;
                    //item.btnaddtoc.Click += BtnAddToCart_Click;
                    flPanel.Controls.Add(item);
                }
                itemC++;
                ItemBarcodes.Add(s.Value.Barcode);
            }
            CBItemCount.SelectedIndex = 0;



            uiBasicSale1.TxtCode.KeyDown += TxtCode_KeyDown;
            uiBasicSale1.TxtQty.KeyDown += TxtQty_KeyDown;
            uiBasicSale1.btnIssue.Click += BtnIssue_Click;
            Forms.frmWaiting = new UIForms.FrmWaiting(UIForms.ServerStatus.Waiting);
            // Forms.frmWaiting.Show();

            #region KeyInput Handle
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            _KeyInput = new RawInput(this.Handle, true);

            _KeyInput.KeyPressed += OnKeyPressed;
            #endregion

            //foreach (var s in _KeyInput._keyboardDriver.GetNames()) Debug.WriteLine($">>{s}");
        }

        private void CartItem_Selected(UItem.CartItemSelectedEventArgs args)
        {
            RepeatedFunctions.AddToCart(ref args.Item, 1, Cart);
            uiBasicSale1.labelTotal.Text = $"Total : Rs.{RepeatedFunctions.RefCart(Cart, DGV).ToString("0.00")}";
        }

        private void OnKeyPressed(object sender, RawInputEventArg e)
        {
            Device = e.KeyPressEvent.DeviceName;
            if (!uiBasicSale1.TxtCode.Focused && Device.ToLower().Contains(Pos_Barcode.ToLower()))
                uiBasicSale1.TxtCode.Select();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            throw new Exception(e.ExceptionObject.ToString());
        }

        private readonly RawInput _KeyInput;

        string Device = "";
        string Pos_Barcode = localSettings.Data.POSBarcodeID;

        List<uint> DrawCodes = new List<uint>(); // Uint Item Codes To Draw In  FlowLayoutPanel

        public List<string> ItemBarcodes = new List<string>();

        public static Dictionary<uint, decimal> Cart = new Dictionary<uint, decimal>();

        uint ItemCode = 0;
        string BeginChar = "i";

        private void UIMenu_Load(object sender, EventArgs e)
        {
            DrawItems(int.Parse(CBItemCount.Text), (int)TxtPageON.Value);
            RepeatedFunctions.CheckBarcodeReader();
        }

        private void TxtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RepeatedFunctions.TxtCode_Handle(uiBasicSale1.TxtCode, uiBasicSale1.TxtQty, Cart, ItemBarcodes, ref ItemCode, ref Device, Pos_Barcode, BeginChar, DGV, uiBasicSale1.labelTotal);
            }
        }

        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RepeatedFunctions.TxtQty_Handle(uiBasicSale1.TxtCode, uiBasicSale1.TxtQty, Cart, ref ItemCode, ref Device, DGV, uiBasicSale1.labelTotal);
            }
        }

        private void BtnIssue_Click(object sender, EventArgs e)
        {
            RepeatedFunctions.IssueItem(Cart);
            uiBasicSale1.labelTotal.Text = $"Total : Rs.{RepeatedFunctions.RefCart(Cart, DGV).ToString("0.00")}";
        }

        #region Draw Item's Usercontrols In FlowLayoutPanel
        void DrawItems(int ItemMax, int PageNO)
        {
            //int count = 0;
            //if (DrawCodes.Count > ItemMax) count = ItemMax;
            //else count = DrawCodes.Count;

            for (int i = 0; i <= DrawCodes.Count; i++)
            {
                try
                {
                    if (flPanel.Controls[i] is UItem S)
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
            if (DrawCodes.Count < flPanel.Controls.Count)
            {
                for (int i = DrawCodes.Count; i < flPanel.Controls.Count; i++)
                {
                    if (flPanel.Controls[i] is UItem S)
                    {
                        S.Visible = false;
                    }
                }
            }
            TxtPageON.Maximum = (flPanel.Controls.Count / ItemMax) + 1;
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
            foreach (var s in client.ps.Live.Items)
            {
                if (s.Key.ToString().Contains(Code.ToString())) DrawCodes.Add(s.Key);
            }
            DrawItems(int.Parse(CBItemCount.Text), (int)TxtPageON.Value);
        }
        void Search_Item(string BarCode)
        {
            DrawCodes.Clear();
            foreach (var s in client.ps.Live.Items)
            {
                if (s.Value.Barcode.ToLower().Contains(BarCode.ToLower())) DrawCodes.Add(s.Key);
            }
            DrawItems(int.Parse(CBItemCount.Text, System.Globalization.NumberStyles.Any), (int)TxtPageON.Value);
        }
        void Search_Item_Name(string Name)
        {
            DrawCodes.Clear();
            foreach (var s in client.ps.Live.Items)
            {
                if (s.Value.name.ToLower().Contains(Name.ToLower())) DrawCodes.Add(s.Key);
            }
            DrawItems(int.Parse(CBItemCount.Text), (int)TxtPageON.Value);
        }
        #endregion

        #region Edit Handle

        private void DGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGV.CurrentCell != null && DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString() != null)
            {
                btnEdit.Enabled = true;
                btnRemove.Enabled = true;
            }
        }

        private void EditQtyOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RepeatedFunctions.EditCart(Forms.frmEditQty.Code, Forms.frmEditQty.TxtQty.Value, Cart);
                uiBasicSale1.labelTotal.Text = $"Total : Rs.{RepeatedFunctions.RefCart(Cart, DGV).ToString("0.00")}";
                Forms.frmEditQty.Close();
            }
        }

        private void EditQtyOK_Click(object sender, EventArgs e)
        {
            RepeatedFunctions.EditCart(Forms.frmEditQty.Code, Forms.frmEditQty.TxtQty.Value, Cart);
            uiBasicSale1.labelTotal.Text = $"Total : Rs.{RepeatedFunctions.RefCart(Cart, DGV).ToString("0.00")}";
            Forms.frmEditQty.Close();
        }

        private void BtnEdit_Click_1(object sender, EventArgs e)
        {
            if (DGV.CurrentCell != null && uint.TryParse(DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString(), out uint uc) && uint.TryParse(DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[3].Value?.ToString(), out uint co))
            {
                Forms.frmEditQty = new UIForms.FrmEditQty(co) { Code = uc };
                Forms.frmEditQty.labelName.Text = $"Name : {client.ps.Live.Items[uc].name}\t Code : {uc.ToString()}";
                Forms.frmEditQty.btnOK.Click += EditQtyOK_Click;
                Forms.frmEditQty.TxtQty.KeyDown += EditQtyOK_KeyDown;
                Forms.frmEditQty.ShowDialog();
            }
            btnEdit.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void BtnRemove_Click_1(object sender, EventArgs e)
        {
            if (DGV.CurrentCell != null && uint.TryParse(DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString(), out uint a))
            {
                RepeatedFunctions.RemoveCart(a, Cart);
                uiBasicSale1.labelTotal.Text = $"Total : Rs.{RepeatedFunctions.RefCart(Cart, DGV).ToString("0.00")}";
            }
            btnEdit.Enabled = false;
            btnRemove.Enabled = false;
        }
        #endregion
    }

    public struct DGVcart_Data
    {
        public uint Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }
        public decimal Total { get; set; }
    }
}
