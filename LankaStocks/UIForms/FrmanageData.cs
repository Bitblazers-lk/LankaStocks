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
    public partial class FrmanageData : Form
    {
        public FrmanageData()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Forms.addData = new UIForms.AddData();
            Forms.addData.Show();
        }

        private void btnStockIntake_Click(object sender, EventArgs e)
        {
            Forms.itemIntake = new UIForms.ItemIntake();
            Forms.itemIntake.Show();
        }
    }
}
