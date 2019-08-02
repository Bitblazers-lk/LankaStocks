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
    public partial class UIAddItem : UserControl
    {
        public UIAddItem()
        {
            InitializeComponent();
        }

        private void ItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Txt(ItemName);
            }
        }

        private void VendorID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Txt(VendorID);
            }
        }

        private void InPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Num(InPrice);
            }
        }

        private void OutPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Num(OutPrice);
            }
        }

        private void InPrice_TextChanged(object sender, EventArgs e)
        {
            Error.Num(InPrice);
        }

        private void OutPrice_TextChanged(object sender, EventArgs e)
        {
            Error.Num(OutPrice);
        }
    }
}
