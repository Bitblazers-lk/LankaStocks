using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LankaStocks.UserControls;
using static LankaStocks.Core;

namespace LankaStocks.Shared
{
    public static class Error
    {
        public static string[] Errors = { "Feild Cannot Be Empty!", "Feild Must Be A Number!" };

        private static bool ShowError(string txt, Control ctrl)
        {
            ctrl.BackColor = Color.FromKnownColor(KnownColor.Red);
            //Core.Log(txt);
            // MessageBox.Show(txt, "LankaStocks - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        public static bool Num(Control Ctrl)
        {
            if (!string.IsNullOrWhiteSpace(Ctrl.Text))
            {
                if (float.TryParse(Ctrl.Text, out float A))
                {
                    Ctrl.BackColor = Color.FromKnownColor(KnownColor.WindowFrame);
                    return true;
                }
                else
                {
                    //Ctrl.Text = Ctrl.Text.Substring(0, Ctrl.Text.Length - 1);
                    //Ctrl.Select();
                    return ShowError(Errors[1], Ctrl);
                }
            }
            else return ShowError(Errors[0], Ctrl);
        }

        public static bool Txt(Control Ctrl)
        {
            if (!string.IsNullOrWhiteSpace(Ctrl.Text))
            {
                Ctrl.BackColor = Color.FromKnownColor(KnownColor.WindowFrame);
                return true;
            }
            else return ShowError(Errors[0], Ctrl);
        }
    }

    public static class RepeatedFunctions
    {
        public static bool CheckBarcodeReader(bool mess = true)
        {
            List<string> DList = new List<string>();
            SelectQuery Sq = new SelectQuery("Win32_Keyboard");
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            foreach (ManagementObject mo in osDetailsCollection)
            {
                DList.Add((string)mo["Description"]);
            }
            if (!DList.Contains(""))
            {
                if (mess)
                    MessageBox.Show("Barcode Reader Not Found!", "LankaStocks > Barcode Reader? - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #region Cart
        public static void AddToCart(uint code, float qty, Dictionary<uint, float> _Cart)
        {
            if (_Cart.ContainsKey(code))
            {
                _Cart[code] += qty;
            }
            else _Cart.Add(code, qty);
            //RefCart(Cart);
        }
        public static void EditCart(uint code, float Newqty, Dictionary<uint, float> _Cart)
        {
            if (_Cart.ContainsKey(code))
            {
                _Cart[code] = Newqty;
            }
            //RefCart(Cart);
        }
        public static void RemoveCart(uint code, Dictionary<uint, float> _Cart)
        {
            if (_Cart.ContainsKey(code))
            {
                _Cart.Remove(code);
            }
            // RefCart(Cart);
        }
        public static void RefCart(Dictionary<uint, float> _Cart, DataGridView DGVcart)
        {
            List<DGVcart_Data> Data = new List<DGVcart_Data>();
            foreach (var s in _Cart)
            {
                var i = RemoteDBs.Live.Items.Get[s.Key];
                Data.Add(new DGVcart_Data { Code = s.Key, Name = i.name, Price = i.outPrice, Qty = s.Value, Total = i.outPrice * (decimal)s.Value });
            }
            DGVcart.DataSource = Data;
        }
        public static uint GetUCode(string Barcode)
        {
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (s.Value.Barcode == Barcode) return s.Key;
            }
            return 0;
        }
        #endregion
    }
}
