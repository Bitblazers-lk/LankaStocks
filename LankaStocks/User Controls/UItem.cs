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

namespace LankaStocks
{
    public partial class UItem : UserControl
    {
        public UItem(string Code)
        {
            InitializeComponent();
        }
        string _Code;
        private void UI_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("OKK");
        }

        private void cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "Images (*.jpg)|*.jpg|(*.png)|*.png| All Files (*.*)|*.*",
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                CopyImage(open.FileName);
            }
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
            if (File.Exists(@"Src\Images\" + _Code + ".png"))
            {
                File.Delete(@"Src\Images\" + _Code + ".png");
            }
            else if (!Directory.Exists(@"Src\Images\"))
            {
                Directory.CreateDirectory(@"Src\Images\");
            }
            bitmap.Save(@"Src\Images\" + _Code + ".png");
            //Pages.Menu.DB.data.Item[_Code].ImPath = @"Src\Images\" + _Code + ".png";
            im.Dispose();
            bitmap.Dispose();
            PB.Image = Image.FromFile(@"Src\Images\" + _Code + ".png");
            //Pages.Menu.DB.Save();
        }
        void LoadImage(string Name)
        {
            try
            {
                PB.Image = Image.FromFile(Name);
            }
            catch { }
        }

        private void UI_Load(object sender, EventArgs e)
        {
            //if (!String.IsNullOrWhiteSpace(Pages.Menu.DB.data.Item[_Code].ImPath))
            //    LoadImage(Pages.Menu.DB.data.Item[_Code].ImPath);
            //l1.Text = Pages.Menu.DB.data.Item[_Code].Name;
            //l2.Text = Pages.Menu.DB.data.Item[_Code].Code;
            //lp.Text = $"Rs.{ Pages.Menu.DB.data.Item[_Code].Price.ToString("00.00")}";
        }

        private void btnaddtoc_Click(object sender, EventArgs e)
        {

        }
    }
}
