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
    public partial class FrmTransaction : Form
    {
        public FrmTransaction()
        {
            InitializeComponent();
        }

        private void FrmTransaction_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
            _ = new PanelMenu(panel2, btnhide, 34, panel2.Width);
            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
        }
    }
}
