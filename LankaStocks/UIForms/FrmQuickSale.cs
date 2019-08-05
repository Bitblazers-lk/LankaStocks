using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LankaStocks.UIForms
{
    public partial class FrmQuickSale : Form
    {
        public FrmQuickSale()
        {
            InitializeComponent();
        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 143)
            {
                panel1.Width = 40;
            }
            else if (panel1.Width == 40)
            {
                panel1.Width = 143;
            }
        }

        private void btnfund_Click(object sender, EventArgs e)
        {
            Forms.frmRefund = new FrmRefund();
            Forms.frmRefund.Show();
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
    }
}
