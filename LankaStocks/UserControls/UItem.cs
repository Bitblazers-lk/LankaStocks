﻿using System;
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

        public uint _Code;

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
            Setdata(_Code);           
        }

        public void Setdata(uint code)
        {
            _Code = code;
            var data = RemoteDBs.Live.Items.Get[code];
            //this.Name = code.ToString();
            l1.Text = data.name;
            l2.Text = data.itemID.ToString();
            lp.Text = $"Rs.{ data.outPrice.ToString("00.00")}";
            if (data.Quantity <= RemoteDBs.Settings.commonSettings.Get.WarnWhen) this.BackColor = Color.FromArgb(200, 0, 0, 100);
        }

        //private void btnaddtoc_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show(this.Size.ToString());
        //}

    }
}
