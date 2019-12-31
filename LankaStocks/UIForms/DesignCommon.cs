using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LankaStocks.GDI;

namespace LankaStocks.UIForms
{
    public partial class DesignCommon : Form
    {
        public DesignCommon()
        {
            InitializeComponent();
            List<IM_Data> D = new List<IM_Data>
            {
                new IM_Data { Date = DateTime.Now.ToShortDateString(),IN_price=(decimal)950000.07,OUT_price=100,IN_qty=0,OUT_qty=90000,BAL_qty=37000 }
            };
            _ = new List<IM1_Data>
            {
                new IM1_Data{Date=DateTime.Now.ToShortDateString(),Name="BOX",Value=100}
            };
            var im = Drawings.DrawTable("box", D)[0];
            pictureBox1.Image = im;
            im.Save("1.png");
        }
    }
}
