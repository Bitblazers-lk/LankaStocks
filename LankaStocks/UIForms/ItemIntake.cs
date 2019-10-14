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

namespace LankaStocks.UIForms
{
    public partial class ItemIntake : Form
    {
        public ItemIntake()
        {
            InitializeComponent();


            uiSaveData.Save.Click += Save_Click;
            uiSaveData.RefreshAll.Click += Refresh_Click;
            uiSaveData.Cancel.Click += Cancel_Click;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Do You Realy Want To Cancel?", "LankaStocks > Calcel?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK) this.Dispose();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Under Development.", "LankaStocks > Under Development?", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Core.client.StockIntake(uiStockIntake.GenerateStockIntake());
            Hide();
        }

        private void ItemIntake_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
        }
    }
}
