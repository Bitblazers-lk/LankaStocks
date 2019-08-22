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
    public partial class FrmQuickSale : Form
    {
        public FrmQuickSale()
        {
            InitializeComponent();
        }
        int ToolBarWidth;
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

        }

        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

        }

        private void FrmQuickSale_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
            ToolBarWidth = panel1.Width;

            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel3.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
        }
    }
}
