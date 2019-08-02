using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LankaStocks.Shared;

namespace LankaStocks.UserControls
{
    public partial class UIStockIntake : UserControl
    {
        public UIStockIntake()
        {
            InitializeComponent();
        }

        private void VendorID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Txt(VendorID);
            }
        }

        private void ItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Txt(ItemID);
            }
        }

        private void Qty_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Num(Qty);
            }
        }

        private void Qty_TextChanged(object sender, EventArgs e)
        {
            Error.Num(Qty);
        }
    }
}
