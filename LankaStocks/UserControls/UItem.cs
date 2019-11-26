using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static LankaStocks.Core;

namespace LankaStocks.UserControls
{
    public partial class UItem : UserControl
    {
        public UItem()
        {
            InitializeComponent();
            //PB.DoubleClick += btnaddtoc_Click;
            //this.DoubleClick += btnaddtoc_Click;
        }

        public uint _Code = 0;

        private void cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                CopyImage(open.FileName);
            }
            open.Dispose();
        }
        void CopyImage(string Path)
        {
            var im = Image.FromFile(Path);
            Bitmap bitmap = new Bitmap(im, new Size(140, 140));
            try
            {
                PB.Image.Dispose();
            }
            catch { }
            if (!Directory.Exists(@"Src\Images\"))
            {
                Directory.CreateDirectory(@"Src\Images\");
            }
            if (File.Exists(@"Src\Images\" + _Code + ".png"))
            {
                PB.Image.Dispose();
                File.Delete(@"Src\Images\" + _Code + ".png");
            }
            bitmap.Save(@"Src\Images\" + _Code + ".png");
            im.Dispose();
            bitmap.Dispose();
            PB.Image = Image.FromFile(@"Src\Images\" + _Code + ".png");
            GC.Collect();
        }
        void LoadImage(uint code)
        {
            try
            {
                PB.Image = Image.FromFile(@"Src\Images\" + code + ".png");
            }
            catch { }
        }

        private void UI_Load(object sender, EventArgs e)
        {
            //if (!String.IsNullOrWhiteSpace(Pages.Menu.DB.data.Item[_Code].ImPath))
            //    LoadImage(Pages.Menu.DB.data.Item[_Code].ImPath);
            Setdata(_Code);
        }

        public void Setdata(uint Ucode)
        {
            //try
            //{
            var data = client.ps.Live.Items[Ucode];
            l1.Text = data.name;
            l2.Text = data.itemID.ToString();
            lp.Text = $"Rs.{ data.outPrice.ToString("00.00")}";
            if (data.Quantity <= client.ps.Settings.commonSettings.WarnWhen) this.BackColor = Color.FromArgb(255, 100, 0, 0);

            // if (data.Quantity==0) this.BackColor = Color.FromArgb(10, 100, 0, 0);
            //}
            //catch { }
            _Code = Ucode;
            LoadImage(_Code);
            GC.Collect();
        }

        private void Btnaddtoc_Click(object sender, EventArgs e)
        {
            var handler = CartItemSelected;
            handler?.Invoke(new CartItemSelectedEventArgs(_Code));

        }


        public event CartItemSelectedEventHandler CartItemSelected;
        public delegate void CartItemSelectedEventHandler(CartItemSelectedEventArgs args);
        public class CartItemSelectedEventArgs : EventArgs
        {
            public uint Item;

            public CartItemSelectedEventArgs(uint item)
            {
                Item = item;
            }
        }

        private void UItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var handler = CartItemSelected;
            handler?.Invoke(new CartItemSelectedEventArgs(_Code));
        }

    }
}
