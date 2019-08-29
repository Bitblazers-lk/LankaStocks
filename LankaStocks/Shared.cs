using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            string a;
            foreach (ManagementObject mo in osDetailsCollection)
            {
                a = (string)mo["DeviceID"];
                a = a.Substring(a.IndexOf(@"\") + 1, a.Substring(a.IndexOf(@"\") + 1).IndexOf(@"\")).ToLower();
                DList.Add(a);
            }
            if (localSettings.Data.POSBarcodeID == null || !DList.Contains(localSettings.Data.POSBarcodeID.ToLower()) && localSettings.Data.POSBarcodeID.ToLower() != "null")
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
        public static void RefCart(Dictionary<uint, float> _Cart, DataGridView _DGVcart)
        {
            List<DGVcart_Data> Data = new List<DGVcart_Data>();
            foreach (var s in _Cart)
            {
                var i = RemoteDBs.Live.Items.Get[s.Key];
                Data.Add(new DGVcart_Data { Code = s.Key, Name = i.name, Price = i.outPrice, Qty = s.Value, Total = i.outPrice * (decimal)s.Value });
            }
            _DGVcart.DataSource = Data;
        }
        public static uint GetUCode(string Barcode)
        {
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (s.Value.Barcode.ToLower() == Barcode.ToLower())
                    return s.Key;
            }
            return 0;
        }
        #endregion

        #region DGV
        public static void MarkWarning(int QtyCindex, DataGridView _DGV)
        {
            float min = RemoteDBs.Settings.commonSettings.Get.WarnWhen;

            for (int a = 0; a < _DGV.RowCount; a++)
            {
                for (int i = 0; i < _DGV.ColumnCount; i++)
                {
                    if (i == QtyCindex && float.TryParse(_DGV.Rows[a].Cells[i].Value.ToString(), out float c) && c <= min)
                    {
                        for (int x = 0; x < _DGV.ColumnCount; x++)
                        {
                            _DGV.Rows[a].Cells[x].Style.ForeColor = Color.Red;
                            //DGV.Rows[a].Cells[i].Style.BackColor = Color.Red;
                        }
                    }
                }
            }
        }
        public static List<DGV_Data> RefStore()
        {
            List<DGV_Data> Data = new List<DGV_Data>();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                Data.Add(new DGV_Data { Code = s.Key, Barcode = s.Value.Barcode, Name = s.Value.name, Price = s.Value.outPrice, Qty = s.Value.Quantity, });
            }
            return Data;
        }
        public static List<DGV_Data> Search_Item(uint Code)
        {
            List<DGV_Data> Data = new List<DGV_Data>();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (s.Key.ToString().Contains(Code.ToString()))
                    Data.Add(new DGV_Data { Code = s.Key, Barcode = s.Value.Barcode, Name = s.Value.name, Price = s.Value.outPrice, Qty = s.Value.Quantity, });
            }
            return Data;
        }
        public static List<DGV_Data> Search_Item_Barcode(string Barcode)
        {
            List<DGV_Data> Data = new List<DGV_Data>();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (s.Value.Barcode.ToLower().Contains(Barcode.ToLower()))
                    Data.Add(new DGV_Data { Code = s.Key, Barcode = s.Value.Barcode, Name = s.Value.name, Price = s.Value.outPrice, Qty = s.Value.Quantity, });
            }
            return Data;
        }
        public static List<DGV_Data> Search_Item_Name(string Name)
        {
            List<DGV_Data> Data = new List<DGV_Data>();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (s.Value.name.ToLower().Contains(Name.ToLower()))
                    Data.Add(new DGV_Data { Code = s.Key, Barcode = s.Value.Barcode, Name = s.Value.name, Price = s.Value.outPrice, Qty = s.Value.Quantity, });
            }
            return Data;
        }
        #endregion

        public static void TxtCode_Handle(TextBox _TxtCode, NumericUpDown _TxtQty, Dictionary<uint, float> _Cart, List<string> _ItemBarcodes, ref uint _ItemCode, string _Device, string _Pos_Barcode, string _BeginChar, DataGridView _DGVcart)
        {
            if (_Device.ToLower().Contains(_Pos_Barcode.ToLower()))
            {
                if (_ItemBarcodes.Contains(_TxtCode.Text))
                {
                    _ItemCode = GetUCode(_TxtCode.Text);
                    AddToCart(_ItemCode, 1, _Cart);
                    RefCart(_Cart, _DGVcart);
                    _TxtCode.Clear();
                    _TxtQty.Value = 1;
                    _TxtCode.Focus();
                }
                else
                {
                    MessageBox.Show("Item Barcode Not Found!", "LanakaStocks - Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _TxtCode.Clear();
                }
            }
            else
            {
                if (_TxtCode.Text.Substring(0, 1) == _BeginChar)
                {
                    if (uint.TryParse(_TxtCode.Text.Substring(1), out _ItemCode) && RemoteDBs.Live.Items.Get.ContainsKey(_ItemCode)) _TxtQty.Focus();
                    else
                    {
                        MessageBox.Show("Item Code Not Found!", "LanakaStocks - Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _TxtCode.Clear();
                    }
                }
                else
                {
                    if (_ItemBarcodes.Contains(_TxtCode.Text))
                    {
                        _ItemCode = GetUCode(_TxtCode.Text);
                        _TxtQty.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Item Barcode Not Found!", "LanakaStocks - Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _TxtCode.Clear();
                    }
                }
            }
            _Device = null;
        }

        public static void TxtQty_Handle(TextBox _TxtCode, NumericUpDown _TxtQty, Dictionary<uint, float> _Cart, ref uint _ItemCode, string _Device, DataGridView _DGVcart)
        {
            AddToCart(_ItemCode, (float)_TxtQty.Value, _Cart);
            RefCart(_Cart, _DGVcart);
            _TxtCode.Clear();
            _TxtQty.Value = 1;
            _TxtCode.Focus();
            _Device = null;
        }

        public static void SaveAsExcel(DataGridView DGV, string FName, string[] Headers)
        {          
            if (DGV.DataSource != null)
            {
                SaveFileDialog savefile = new SaveFileDialog
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*",
                    FileName = FName + "csv"
                };
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(savefile.FileName, false))
                    {
                        for (int i = 0; i < Headers.Length; i++)
                        {
                            writer.Write(Headers[i] + ",");
                        }
                        writer.Write("\n");
                        for (int a = 0; a < DGV.RowCount; a++)
                        {
                            for (int i = 0; i < DGV.ColumnCount; i++)
                            {
                                writer.Write(DGV[i, a].Value.ToString() + ",");
                            }
                            writer.Write("\n");
                        }
                    }
                }
            }
        }
    }
}
