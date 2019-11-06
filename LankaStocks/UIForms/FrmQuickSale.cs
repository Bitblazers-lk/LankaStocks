using LankaStocks.KeyInput;
using LankaStocks.Setting;
using LankaStocks.Shared;
using LankaStocks.UIHandle;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
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

            #region KeyInput Handle
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            _KeyInput = new RawInput(this.Handle, true);

            _KeyInput.KeyPressed += OnKeyPressed;
            #endregion
        }

        private readonly RawInput _KeyInput;

        string Device="";
        string Pos_Barcode = localSettings.Data.POSBarcodeID;

        uint ItemCode = 0;
        string BeginChar = "i";
        List<string> ItemBarcodes = new List<string>();
        public static Dictionary<uint, decimal> Cart = new Dictionary<uint, decimal>();
        private ContextMenuStrip cm = new ContextMenuStrip();

        private void OnKeyPressed(object sender, RawInputEventArg e)
        {
            Device = e.KeyPressEvent.DeviceName;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            throw new Exception(e.ExceptionObject.ToString());
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (DGV.CurrentCell != null && uint.TryParse(DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString(), out uint Uc) && uint.TryParse(DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[3].Value?.ToString(), out uint co))
            {
                Forms.frmEditQty = new UIForms.FrmEditQty(co) { Code = Uc };
                Forms.frmEditQty.labelName.Text = $"Name : {RemoteDBs.Live.Items.Get[Uc].name}\t Code : {Uc.ToString()}";
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
                labelTotal.Text = $"Total : Rs.{RepeatedFunctions.RefCart(Cart, DGV).ToString("0.00")}";
            }
        }

        private void EditQtyOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RepeatedFunctions.EditCart(Forms.frmEditQty.Code, Forms.frmEditQty.TxtQty.Value, Cart);
                labelTotal.Text = $"Total : Rs.{RepeatedFunctions.RefCart(Cart, DGV).ToString("0.00")}";
                Forms.frmEditQty.Close();
            }
        }

        private void EditQtyOK_Click(object sender, EventArgs e)
        {
            RepeatedFunctions.EditCart(Forms.frmEditQty.Code, Forms.frmEditQty.TxtQty.Value, Cart);
            labelTotal.Text = $"Total : Rs.{RepeatedFunctions.RefCart(Cart, DGV).ToString("0.00")}";
            Forms.frmEditQty.Close();
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
                RepeatedFunctions.TxtCode_Handle(TxtCode, TxtQty, Cart, ItemBarcodes, ref ItemCode, Device, Pos_Barcode, BeginChar, DGV, labelTotal);
            }
        }

        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RepeatedFunctions.TxtQty_Handle(TxtCode, TxtQty, Cart, ref ItemCode, Device, DGV, labelTotal);
            }
        }

        private void BtnIssue_Click(object sender, EventArgs e)
        {
            RepeatedFunctions.IssueItem(Cart);
            labelTotal.Text = $"Total : Rs.{RepeatedFunctions.RefCart(Cart, DGV).ToString("0.00")}";
        }

        private void FrmQuickSale_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
            PanelMenu panelMenu = new PanelMenu(panel1, btnhide, 34, panel1.Width);

            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel3.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;

            #region ContextMenu
            cm.Items.Add("Edit", Properties.Resources.edit_24px, new EventHandler(Edit_Click));
            cm.Items.Add("Remove", Properties.Resources.delete_sign_24px, new EventHandler(Remove_Click));
            cm.BackColor = Color.LightGray;
            #endregion

            labelTotal.Font = new Font(labelTotal.Font.Name.ToString(), labelTotal.Font.Size + 5);
            labelInNO.Font = new Font(labelInNO.Font.Name.ToString(), labelInNO.Font.Size + 2);
            RepeatedFunctions.CheckBarcodeReader();
        }

        private void DGV_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.ContextMenuStrip != cm)
            {
                DGV.ContextMenuStrip = cm;
            }
        }

        private void DGV_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.ContextMenuStrip != null)
            {
                DGV.ContextMenuStrip = null;
            }
        }


    }
}
