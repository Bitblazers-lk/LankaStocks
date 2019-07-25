using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LankaStocks
{
    public partial class UIMenu : UserControl
    {
        public UIMenu()
        {
            InitializeComponent();

            flowLayoutPanel1.Controls.Add(new UItem("01"));

            //DGV.DataSource = Forms.m.i;
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
