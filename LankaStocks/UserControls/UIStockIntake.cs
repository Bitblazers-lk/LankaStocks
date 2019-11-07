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
        public StockIntake GenerateStockIntake()
        {
            uint intakeID = 0;
            if (IntakeID.Text == "") IntakeID.Text = "0";
            if (!uint.TryParse(IntakeID.Text, out intakeID))
            {
                throw new ArgumentException("Value must be a positive integer", "intakeID");
            }

            StockIntake intake = new StockIntake() { IntakeID = intakeID, item = new Item() };
            ApplyTo(intake);
            return intake;

        }
        public void ApplyTo(StockIntake si)
        {
            si.item.itemID = uiSelItem.GetItem();

            Item RootItem;
            //try
            //{
            RootItem = Core.RemoteDBs.Live.Items.GetItem(si.item.itemID);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception($"Item {si.item.itemID} is not found in the server", ex);
            //}


            if (!decimal.TryParse(Qty.Text, out decimal qty)) throw new ArgumentNullException("Qty", "Quantity cannot be null");

            si.item.Quantity = qty;

           // si.trans = uiTransaction.GenerateTransaction();

            uint vendID = uiSelecVendor.GetPersonTypeAndID().ID;
            si.item.vendors = new List<uint>() { vendID };


            if (!RootItem.vendors.Contains(vendID)) RootItem.vendors.Add(vendID);

            si.item.inPrice = RootItem.inPrice;
            si.item.outPrice = RootItem.outPrice;


            RootItem.Quantity += qty;
        }
    }
}

