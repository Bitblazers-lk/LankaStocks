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
using LankaStocks.Shared;

namespace LankaStocks.UIForms
{
    public partial class FrmanageItems : Form
    {
        public FrmanageItems()
        {
            InitializeComponent();
        }
        int ToolBarWidth;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Forms.addItems = new UIForms.AddItems();
            Forms.addItems.ShowDialog();
        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            if (panel2.Width == ToolBarWidth)
            {
                panel2.Width = 35;
            }
            else if (panel2.Width == 35)
            {
                panel2.Width = ToolBarWidth;
            }
        }

        private void btnStockIntake_Click(object sender, EventArgs e)
        {
            Forms.itemIntake = new UIForms.ItemIntake();
            Forms.itemIntake.ShowDialog();
        }

        private void FrmanageItems_Load(object sender, EventArgs e)
        {
            FrmItemView view = new FrmItemView(client.ps.Live.Items, splitContainer2.Panel2);
            FormHandle form = new FormHandle();
            form.OpenForm(splitContainer1.Panel1, view, FormBorderStyle.None, DockStyle.Fill);
            Settings.LoadCtrlSettings(this);

            ToolBarWidth = panel2.Width;
            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
        }
    }

    public struct DGVMI_Data
    {
        public uint Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public decimal In_Price { get; set; }
        public decimal Out_Price { get; set; }
        public decimal Qty { get; set; }
        public string Vendor { get; set; }
        public uint Alternative { get; set; }
    }
}
