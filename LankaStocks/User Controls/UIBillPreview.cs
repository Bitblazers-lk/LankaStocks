using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LankaStocks.User_Controls
{
    public partial class UIBillPreview : UserControl
    {
        public UIBillPreview(Image Im)
        {
            InitializeComponent();
            PictureBox PB = new PictureBox { Image = Im };
            PB.SizeMode = PictureBoxSizeMode.AutoSize;
            PB.Controls.Add(PB);
        }
    }
}
