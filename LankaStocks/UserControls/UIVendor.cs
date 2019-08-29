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
    public partial class UIVendor : UserControl
    {
        public UIVendor()
        {
            InitializeComponent();
        }

        private void BusinessInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Error.Txt(BusinessInfo);
            }
        }
        public Vendor GenerateVendor()
        {
            if (VendorID.Text == "") VendorID.Text = "0";
            if (!uint.TryParse(VendorID.Text, out uint vendorID))
            {
                throw new ArgumentException("Value must be a positive integer", "vendorID");
            }

            Vendor v = new Vendor
            {
                BusinessInfo = BusinessInfo.Text,
                ID = vendorID
            };

            uiPerson1.ApplyToPerson(v);

            return v;
        }
    }
}
