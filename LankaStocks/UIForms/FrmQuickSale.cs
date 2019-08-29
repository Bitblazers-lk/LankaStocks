using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using LankaStocks.KeyInput;
using LankaStocks.Setting;
using LankaStocks.Shared;
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
            #region ContextMenu
            cm.Items.Add("Edit", new Bitmap(10, 10), new EventHandler(Edit_Click));
            cm.Items.Add("Remove", new Bitmap(10, 10), new EventHandler(Remove_Click));
            DGV.ContextMenuStrip = cm;
            #endregion

            #region KeyInput Handle
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            _KeyInput = new RawInput(this.Handle, true);

            _KeyInput.KeyPressed += OnKeyPressed;
            #endregion
        }

        private readonly RawInput _KeyInput;

        string Device;
        string Pos_Barcode = localSettings.Data.POSBarcodeID;

        int ToolBarWidth;
        uint ItemCode = 0;
        string BeginChar = "i";
        List<string> ItemBarcodes = new List<string>();
        public static Dictionary<uint, float> Cart = new Dictionary<uint, float>();

        ContextMenuStrip cm = new ContextMenuStrip();

        private void OnKeyPressed(object sender, RawInputEventArg e)
        {
            Device = e.KeyPressEvent.DeviceName;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // throw new NotImplementedException();
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
            if (DGV.CurrentCell != null && uint.TryParse(DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString(), out uint a))
            {
                RepeatedFunctions.RemoveCart(a, Cart);
                RepeatedFunctions.RefCart(Cart, DGV);
            }
        }

        private void EditQtyOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RepeatedFunctions.EditCart(Forms.frmEditQty.Code, (float)Forms.frmEditQty.TxtQty.Value, Cart);
                RepeatedFunctions.RefCart(Cart, DGV);
                Forms.frmEditQty.Close();
            }
        }

        private void EditQtyOK_Click(object sender, EventArgs e)
        {
            RepeatedFunctions.EditCart(Forms.frmEditQty.Code, (float)Forms.frmEditQty.TxtQty.Value, Cart);
            RepeatedFunctions.RefCart(Cart, DGV);
            Forms.frmEditQty.Close();
        }

        private void Btnhide_Click(object sender, EventArgs e)
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

        private void Btnfund_Click(object sender, EventArgs e)
        {
            Forms.frmRefund = new FrmRefund();
            Forms.frmRefund.ShowDialog();
        }

        private void TxtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RepeatedFunctions.TxtCode_Handle(TxtCode, TxtQty, Cart, ItemBarcodes, ref ItemCode, Device, Pos_Barcode, BeginChar, DGV);
            }
        }

        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RepeatedFunctions.TxtQty_Handle(TxtCode, TxtQty, Cart, ref ItemCode, Device, DGV);
            }
        }

        private void BtnIssue_Click(object sender, EventArgs e)
        {

        }

        private void FrmQuickSale_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
            ToolBarWidth = panel1.Width;

            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel3.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            RepeatedFunctions.CheckBarcodeReader();
        }
    }
}
