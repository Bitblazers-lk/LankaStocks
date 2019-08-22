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
    public partial class FrmEditQty : Form
    {
        public FrmEditQty()
        {
            InitializeComponent();
        }
        public uint Code;
        private void FrmEditQty_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
