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
using LankaStocks.UIHandle;
using static LankaStocks.Core;

namespace LankaStocks.UIForms
{
    public partial class FrmCharts : Form
    {
        public FrmCharts()
        {
            InitializeComponent();
        }

        private void FrmCharts_Load(object sender, EventArgs e)
        {
            _ = new PanelMenu(panel2, btnhide, 34, panel2.Width);
            Settings.LoadCtrlSettings(this);
            this.panel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
        }
    }
}
