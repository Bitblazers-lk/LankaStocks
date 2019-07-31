using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LankaStocks
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        public List<string> i = new List<string>();

        private void btnhide_Click(object sender, EventArgs e)
        {
            if (panel2.Width == 200)
            {
                panel2.Width = 40;
                btnabout.Text = "";
            }
            else if (panel2.Width == 40)
            {
                panel2.Width = 200;
                btnabout.Text = "About";
            }
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Core.Shutdown();
        }

        private void btnIssueItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnManageItem_Click(object sender, EventArgs e)
        {
            Forms.frmanageItems = new UIForms.FrmanageItems();
            Forms.frmanageItems.Show();
        }

        private void btnManageData_Click(object sender, EventArgs e)
        {
            Forms.frmanageData = new UIForms.FrmanageData();
            Forms.frmanageData.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            Forms.frmSales = new UIForms.FrmSales();
            Forms.frmSales.Show();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            Forms.frmTransaction = new UIForms.FrmTransaction();
            Forms.frmTransaction.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Forms.frmSettings = new UIForms.FrmSettings();
            Forms.frmSettings.Show();
        }
    }
}
