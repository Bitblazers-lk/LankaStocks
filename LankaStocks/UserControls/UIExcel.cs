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
            //MYdgv = _DGV;
            //_ColNames = ColNames;
        }
        DataGridView MYdgv;
        string[] _ColNames;
        private bool init = false;
        private string Nm = "";

        public void Set(DataGridView _DGV, string[] ColNames)
        {
            MYdgv = _DGV;
            _ColNames = ColNames;
            init = true;
        }
        public void SetFileName(string name)
        {
            Nm = name;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (init)
                RepeatedFunctions.SaveAsExcel(MYdgv, Nm, _ColNames);
        }
    }
}
