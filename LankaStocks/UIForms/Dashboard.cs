using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LankaStocks
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        public List<string> i = new List<string>();



        public Point downPoint = Point.Empty;

        private void btnhide_Click(object sender, EventArgs e)
        {
            if (panel2.Width == 200)
            {
                panel2.Width = 40;
                btnabout.Text = "";
            }
            else if (panel2.Width == 40)
            {
                panel2.Width = 200;
                btnabout.Text = "About";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Core.Shutdown();
        }
    }
}
