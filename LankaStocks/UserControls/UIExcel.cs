using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LankaStocks.Shared;
using static LankaStocks.Core;

namespace LankaStocks.UserControls
{
    public partial class UIExcel : UserControl
    {
        public UIExcel()
        {
            InitializeComponent();
            MYdgv = new DataGridView();
            _ColNames = new string[4];
        }
        DataGridView MYdgv;
        string[] _ColNames;

        private void Button3_Click(object sender, EventArgs e)
        {
            RepeatedFunctions.SaveAsExcel(MYdgv, "", _ColNames);
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
