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

namespace LankaStocks.UIForms
{
    public partial class FrmSales : Form
    {
        public FrmSales()
        {
            InitializeComponent();


            cHUserProfie.Dock = DockStyle.Fill;
            panel3.Controls.Add(cHUserProfie);

            cHUserProfie.Draw(new Dictionary<string, List<double>> { { "Hari", new List<double> { 5, 8, 2, 6, 3, 9 } }, { "Kari", new List<double> { 4, 2, 8, 7, 3, 1 } } }, new List<string> { "09:12:05", "10:12:05", "11:12:05", "12:12:05", "13:12:05", "14:12:05" });

            //cHSalesRealTime.Dock = DockStyle.Fill;
            //panel3.Controls.Add(cHSalesRealTime);
        }
        CHSalesRealTime cHSalesRealTime = new CHSalesRealTime(1000, "Sales", true);
        CHUserProfie cHUserProfie = new CHUserProfie();

        int ToolBarWidth;
        private void Btnhide_Click(object sender, EventArgs e)
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

        private void FrmSales_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
            ToolBarWidth = panel2.Width;
            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
        }
        Random R = new Random();

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //cHSalesRealTime.Draw(R.Next(25, 1000));
            //timer1.Interval = R.Next(100, 3000);
        }

        private void BtnChart_Click(object sender, EventArgs e)
        {
            Forms.frmCharts = new FrmCharts();
            Forms.frmCharts.Show();
        }
    }
}
