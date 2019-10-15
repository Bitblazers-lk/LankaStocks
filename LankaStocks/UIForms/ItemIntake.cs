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
            var res = MessageBox.Show("Do You Realy Want To Cancel?", "LankaStocks > Cancel?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK) this.Dispose();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This Feature Is Under Development.", "LankaStocks > Under Development?", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var resp = client.StockIntake(uiStockIntake.GenerateStockIntake());

            if (resp.result == (byte)Networking.Response.Result.ok)
            {
                Log($"Done Stock Intake... By {user.userName}");
                MessageBox.Show("Done Stock Intake!", "LankaStocks > Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
            }
            else
            {
                string s = $" Stock Intake failed. {((Networking.Response.Result)resp.result).ToString()} - {resp.msg}";
                Log(s);
                MessageBox.Show(s, "LanakaStocks > Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ItemIntake_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
        }
    }
}
