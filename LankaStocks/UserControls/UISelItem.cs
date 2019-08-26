using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LankaStocks.UserControls
{
    public partial class UISelItem : UserControl
    {

        Dictionary<uint, string> items;
        public UISelItem()
        {
            InitializeComponent();

            ShowItems();

        }

        public void ShowItems()
        {

            if (!Core.IsInitialized) return;

            Cmb.Items.Clear();
            items = (Dictionary<uint, string>)Core.client.ListItems().obj;

            foreach (var item in items)
            {
                Cmb.Items.Add(item.Value);
            }
        }

        public uint GetItem()
        {
            return items.ElementAt(Cmb.SelectedIndex).Key;
        }
    }
}
