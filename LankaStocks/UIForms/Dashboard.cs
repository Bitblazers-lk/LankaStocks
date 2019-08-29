using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LankaStocks.UserControls;
using LankaStocks.Setting;
using static LankaStocks.Core;
//41, 11, 31
namespace LankaStocks.UIForms
{
    public partial class Dashboard : Form
    {
        UIMenu menuModern = new UIMenu { Dock = DockStyle.Fill };
        UIMenuA menuClassic = new UIMenuA { Dock = DockStyle.Fill };

        public Dashboard()
        {
            InitializeComponent();
            if (RemoteDBs.Settings.commonSettings.Get.Interface == MenuInterfaceType.Classic)
                this.panel4.Controls.Add(menuClassic);
            else this.panel4.Controls.Add(menuModern);

            Settings.LoadCtrlSettings(this);

            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;

            #region ContextMenu
            cmOQC.MenuItems.Add("Open Quick Sell Window", new EventHandler(Open_QC_Window_Click));
            btnIssueItem.ContextMenu = cmOQC;

            cmLout.MenuItems.Add("Sign Out", new EventHandler(Sign_Out_Click));
            cmLout.MenuItems.Add("Restart", new EventHandler(Restart_Click));
            cmLout.MenuItems.Add("Exit", new EventHandler(Exit_Click));
            cmLout.MenuItems.Add("Help", new EventHandler(Help_Click));
            btnhide.ContextMenu = cmLout;
            #endregion

        }

        private void Help_Click(object sender, EventArgs e)
        {

        }

        private void Restart_Click(object sender, EventArgs e)
        {
            Core.Shutdown();
            Application.Restart();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Core.Shutdown();
        }

        private void Sign_Out_Click(object sender, EventArgs e)
        {
            Forms.login.Show();
            this.Hide();
        }

        public List<string> i = new List<string>();
        int ToolBarWidth;
        ContextMenu cmOQC = new ContextMenu();
        ContextMenu cmLout = new ContextMenu();

        #region This Form
        private void Btnhide_Click(object sender, EventArgs e)
        {
            if (panel2.Width == ToolBarWidth)
            {
                panel2.Width = 35;
                pblogo.Visible = false;
                btnabout.Text = "";
                btnSettings.Text = "";
            }
            else if (panel2.Width == 35)
            {
                pblogo.Visible = true;
                panel2.Width = ToolBarWidth;
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
            Forms.frmSettings = new UIForms.FrmSettings(false);
            Forms.frmSettings.ShowDialog();
        }

        private void Open_QC_Window_Click(object sender, EventArgs e)
        {
            Forms.frmQuickSale = new FrmQuickSale();
            Forms.frmQuickSale.ShowDialog();
        }
        #endregion

        private void Dashboard_Load(object sender, EventArgs e)
        {
            ToolBarWidth = panel2.Width;
            //Settings.FocusFrm(this);
            //Settings.Virtual_Mouse_Move(100, 0);
            //for (int i = 0; i < 100; i++)
            //{
            //    Settings.Virtual_Mouse_Move(i*5, 100);
            //    Thread.Sleep(10);
            //}
        }

        void IssueItems(Dictionary<uint, float> Cart)
        {

        }
    }
}
