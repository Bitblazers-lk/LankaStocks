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
using LankaStocks.Charts;
using static LankaStocks.Core;
using LankaStocks.UIHandle;

namespace LankaStocks.UIForms
{
    public partial class FrmSales : Form
    {
        public FrmSales()
        {
            InitializeComponent();
        }

        private void FrmSales_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
            PanelMenu panelMenu = new PanelMenu(panel2, btnhide, 34, panel2.Width);
            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

        }

        private void BtnChart_Click(object sender, EventArgs e)
        {
            Forms.frmCharts = new FrmCharts();
            Forms.frmCharts.Show();
        }
    }
}
