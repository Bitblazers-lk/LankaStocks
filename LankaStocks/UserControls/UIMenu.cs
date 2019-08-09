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
                    UItem item = new UItem { _Code = s.Key };
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
        }

        List<uint> DrawCodes = new List<uint> { 1, 2 };
        List<string> ItemBarcodes = new List<string>();

        public Dictionary<uint, float> Cart = new Dictionary<uint, float>();
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
        }

        private void CBItemCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawItems(int.Parse(CBItemCount.Text), (int)TxtPageON.Value);
        }

        private void TxtPageON_ValueChanged(object sender, EventArgs e)
        {
            DrawItems(int.Parse(CBItemCount.Text), (int)TxtPageON.Value);
        }

        private void TxtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (uiBasicSale1.TxtCode.Text.Substring(0, 1) == BeginChar)
                {
                    uint.TryParse(uiBasicSale1.TxtCode.Text.Substring(1), out ItemCode);
                    if (RemoteDBs.Live.Items.Get.ContainsKey(ItemCode)) uiBasicSale1.TxtQty.Focus();
                    else MessageBox.Show("Item Code Not Found!", "LanakaStocks - Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (ItemBarcodes.Contains(uiBasicSale1.TxtCode.Text)) uiBasicSale1.TxtQty.Focus();
                    else MessageBox.Show("Item Barcode Not Found!", "LanakaStocks - Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddToCart(ItemCode, (float)uiBasicSale1.TxtQty.Value);
            }
        }

        void AddToCart(uint code, float qty)
        {
            if (Cart.ContainsKey(code))
            {
                 Cart[code] += qty;
            }
            else Cart.Add(code, qty);
        }

        void EditCart(uint code, float Newqty)
        {
            if (Cart.ContainsKey(code))
            {
                Cart[code] = Newqty;
            }
        }

        void RemoveCart(uint code)
        {
            if (Cart.ContainsKey(code))
            {
                Cart.Remove(code);
            }
        }

        private void BtnIssue_Click(object sender, EventArgs e)
        {

        }
    }
}
