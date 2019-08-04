using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LankaStocks.DataBases;
using LankaStocks;

namespace LankaStocks.UIForms
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();

            // if(Core.client.)
            uiColourMenu.Browse.Click += MenuBrowse_Click;
            uiColourBack.Browse.Click += BackBrowse_Click;
            uiColourItem.Browse.Click += ItemBrowse_Click;
            uiColourFont.Browse.Click += FontBrowse_Click;
        }
        private void MenuBrowse_Click(object sender, EventArgs e)
        {
            CD.AllowFullOpen = false;
            CD.AnyColor = true;
            CD.SolidColorOnly = false;
            //  CD.Color = se
            if (CD.ShowDialog() == DialogResult.OK)
            {
                uiColourMenu.ColourBox.BackColor = CD.Color;
            }
        }
        private void BackBrowse_Click(object sender, EventArgs e)
        {
            CD.AllowFullOpen = false;
            CD.AnyColor = true;
            CD.SolidColorOnly = false;
            //  CD.Color = se
            if (CD.ShowDialog() == DialogResult.OK)
            {
                uiColourBack.ColourBox.BackColor = CD.Color;
            }
        }
        private void ItemBrowse_Click(object sender, EventArgs e)
        {
            CD.AllowFullOpen = false;
            CD.AnyColor = true;
            CD.SolidColorOnly = false;
            //  CD.Color = se
            if (CD.ShowDialog() == DialogResult.OK)
            {
                uiColourItem.ColourBox.BackColor = CD.Color;
            }
        }
        private void FontBrowse_Click(object sender, EventArgs e)
        {
            CD.AllowFullOpen = false;
            CD.AnyColor = true;
            CD.SolidColorOnly = false;
            //  CD.Color = se
            if (CD.ShowDialog() == DialogResult.OK)
            {
                uiColourFont.ColourBox.BackColor = CD.Color;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
        }
    }
}
