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
using static System.Windows.Forms.TabControl;
using static LankaStocks.Core;

namespace LankaStocks.UIForms
{
    public partial class FrmanageData : Form
    {
        public FrmanageData()
        {
            InitializeComponent();
        }

        int ToolBarWidth;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Forms.addData = new UIForms.AddData();
            Forms.addData.ShowDialog();
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

        private void FrmanageData_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
            ToolBarWidth = panel2.Width;
            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
        }

        private void btnperson_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void btnvendor_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
    }
}
