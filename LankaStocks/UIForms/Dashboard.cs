using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LankaStocks.UserControls;
using LankaStocks.Setting;
using LankaStocks.Shared;
using static LankaStocks.Core;
using System.Runtime.InteropServices;
//41, 11, 31
namespace LankaStocks.UIForms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            UIMenu menu = new UIMenu
            {
                Dock = DockStyle.Fill
            };
            this.panel4.Controls.Add(menu);

            Settings.LoadCtrlSettings(this);

            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;

            FrmIosButton b = new FrmIosButton();
            b.Show();

            cm.MenuItems.Add("Open Quick Sell Window", new EventHandler(Open_QC_Window_Click));
            btnIssueItem.ContextMenu = cm;

            notifyIcon1.ShowBalloonTip(1500, "HI", "Hari", ToolTipIcon.Info);
        }

        private void Open_QC_Window_Click(object sender, EventArgs e)
        {
            Forms.frmQuickSale = new FrmQuickSale();
            Forms.frmQuickSale.ShowDialog();
        }

        public List<string> i = new List<string>();
        ContextMenu cm = new ContextMenu();
        private void Btnhide_Click(object sender, EventArgs e)
        {
            if (panel2.Width == 220)
            {
                panel2.Width = 35;
                btnabout.Text = "";
                btnSettings.Text = "";
            }
            else if (panel2.Width == 35)
            {
                panel2.Width = 220;
                btnabout.Text = "About";
                btnSettings.Text = "Settings";
            }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Core.Shutdown();
        }

        private void BtnIssueItem_Click(object sender, EventArgs e)
        {

        }

        private void BtnManageItem_Click(object sender, EventArgs e)
        {
            Forms.frmanageItems = new UIForms.FrmanageItems();
            Forms.frmanageItems.Show();
        }

        private void BtnManageData_Click(object sender, EventArgs e)
        {
            Forms.frmanageData = new UIForms.FrmanageData();
            Forms.frmanageData.Show();
        }

        private void BtnSales_Click(object sender, EventArgs e)
        {
            Forms.frmSales = new UIForms.FrmSales();
            Forms.frmSales.Show();
        }

        private void BtnTransaction_Click(object sender, EventArgs e)
        {
            Forms.frmTransaction = new UIForms.FrmTransaction();
            Forms.frmTransaction.Show();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            Forms.frmSettings = new UIForms.FrmSettings();
            Forms.frmSettings.ShowDialog();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            Settings.FocusFrm(this);
        }
    }
}
