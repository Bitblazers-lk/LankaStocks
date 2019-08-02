using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LankaStocks.UIForms
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();

            // if(Core.client.)

            uiSaveData1.Save.Click += Save_Click;

        }

        private void Save_Click(object sender, EventArgs e)
        {
        }
    }
}
