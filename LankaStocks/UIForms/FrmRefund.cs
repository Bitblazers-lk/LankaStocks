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
    public partial class FrmRefund : Form
    {
        public FrmRefund()
        {
            InitializeComponent();
        }

        private void TxtInNO_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TxtCode_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TxtQyt_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void FrmRefund_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
        }
    }
}
