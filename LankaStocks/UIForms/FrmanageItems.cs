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
    public partial class FrmanageItems : Form
    {
        public FrmanageItems()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Forms.addItems = new UIForms.AddItems();
            Forms.addItems.Show();
        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            if (panel2.Width == 200)
            {
                panel2.Width = 40;
            }
            else if (panel2.Width == 40)
            {
                panel2.Width = 200;
            }
        }

        private void btnStockIntake_Click(object sender, EventArgs e)
        {
            Forms.itemIntake = new UIForms.ItemIntake();
            Forms.itemIntake.Show();
        }

        private void FrmanageItems_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                Settings.LoadCtrlSettings(ctrl);
            }

            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
        }
    }
}
