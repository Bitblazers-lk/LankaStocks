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

        private static bool ShowError(Control ctrl)
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
                    return ShowError(Ctrl);
                }
            }
            else return ShowError(Ctrl);
        }

        public static bool Txt(Control Ctrl)
        {
            if (!string.IsNullOrWhiteSpace(Ctrl.Text))
            {
                Ctrl.BackColor = Color.FromKnownColor(KnownColor.WindowFrame);
                return true;
            }
            else return ShowError(Ctrl);
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
            objOSDetails.Dispose();
            if (localSettings.Data.POSBarcodeID == null || !DList.Contains(localSettings.Data.POSBarcodeID.ToLower()) && localSettings.Data.POSBarcodeID.ToLower() != "null")
            {
                if (mess)
                    MessageBox.Show("Barcode Reader Not Found!", "LankaStocks > Barcode Reader? - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #region Cart
        public static void AddToCart(ref uint code, decimal qty, Dictionary<uint, decimal> _Cart)
        {
            if (client.ps.Live.Items.ContainsKey(code))
            {
                if (_Cart.ContainsKey(code))
                {
                    _Cart[code] += qty;
                }
                else _Cart.Add(code, qty);
            }
            code = 0;
            //RefCart(Cart);
        }
        public static void EditCart(uint code, decimal Newqty, Dictionary<uint, decimal> _Cart)
        {
            if (_Cart.ContainsKey(code))
            {
                _Cart[code] = Newqty;
            }
            //RefCart(Cart);
        }
        public static void RemoveCart(uint code, Dictionary<uint, decimal> _Cart)
        {
            if (_Cart.ContainsKey(code))
            {
                _Cart.Remove(code);
            }
            // RefCart(Cart);
        }
        public static decimal RefCart(Dictionary<uint, decimal> _Cart, DataGridView _DGVcart)
        {
            List<DGVcart_Data> Data = new List<DGVcart_Data>();
            var d = RemoteDBs.Live.Items.Get;
            decimal tot = 0;
            foreach (var s in _Cart)
            {
                var i = d[s.Key];
                tot += i.outPrice * (decimal)s.Value;
                Data.Add(new DGVcart_Data { Code = s.Key, Name = i.name, Price = i.outPrice, Qty = s.Value, Total = i.outPrice * (decimal)s.Value });
            }
            _DGVcart.DataSource = Data;
            return tot;
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
            decimal min = client.ps.Settings.commonSettings.WarnWhen;

            for (int a = 0; a < _DGV.RowCount; a++)
            {
                for (int i = 0; i < _DGV.ColumnCount; i++)
                {
                    if (i == QtyCindex && decimal.TryParse(_DGV.Rows[a].Cells[i].Value.ToString(), out decimal c) && c <= min)
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
                Data.Add(new DGV_Data { Code = s.Key, Barcode = s.Value.Barcode, Name = s.Value.name, Price = s.Value.outPrice, Qty = (float)s.Value.Quantity, });
            }
            return Data;
        }
        public static List<DGV_Data> Search_Item(uint Code)
        {
            List<DGV_Data> Data = new List<DGV_Data>();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (s.Key.ToString().Contains(Code.ToString()))
                    Data.Add(new DGV_Data { Code = s.Key, Barcode = s.Value.Barcode, Name = s.Value.name, Price = s.Value.outPrice, Qty = (float)s.Value.Quantity, });
            }
            return Data;
        }
        public static List<DGV_Data> Search_Item_Barcode(string Barcode)
        {
            List<DGV_Data> Data = new List<DGV_Data>();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (s.Value.Barcode != null && s.Value.Barcode.ToLower().Contains(Barcode.ToLower()))
                    Data.Add(new DGV_Data { Code = s.Key, Barcode = s.Value.Barcode, Name = s.Value.name, Price = s.Value.outPrice, Qty = (float)s.Value.Quantity, });
            }
            return Data;
        }
        public static List<DGV_Data> Search_Item_Name(string Name)
        {
            List<DGV_Data> Data = new List<DGV_Data>();
            foreach (var s in RemoteDBs.Live.Items.Get)
            {
                if (s.Value.name.ToLower().Contains(Name.ToLower()))
                    Data.Add(new DGV_Data { Code = s.Key, Barcode = s.Value.Barcode, Name = s.Value.name, Price = s.Value.outPrice, Qty = (float)s.Value.Quantity, });
            }
            return Data;
        }
        #endregion

        public static void TxtCode_Handle(TextBox _TxtCode, NumericUpDown _TxtQty, Dictionary<uint, decimal> _Cart, List<string> _ItemBarcodes, ref uint _ItemCode, string _Device, string _Pos_Barcode, string _BeginChar, DataGridView _DGVcart, Label _LabTotal)
        {
            if (_Device.ToLower().Contains(_Pos_Barcode.ToLower()))
            {
                if (_ItemBarcodes.Contains(_TxtCode.Text))
                {
                    _ItemCode = GetUCode(_TxtCode.Text);
                    AddToCart(ref _ItemCode, 1, _Cart);
                    _LabTotal.Text = $"Total : Rs.{ RefCart(_Cart, _DGVcart).ToString("0.00")}";
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
                if (!string.IsNullOrWhiteSpace(_TxtCode.Text))
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
            }
            _Device = "";
        }

        public static void TxtQty_Handle(TextBox _TxtCode, NumericUpDown _TxtQty, Dictionary<uint, decimal> _Cart, ref uint _ItemCode, string _Device, DataGridView _DGVcart, Label _LabTotal)
        {
            AddToCart(ref _ItemCode, _TxtQty.Value, _Cart);
            _LabTotal.Text = $"Total : Rs.{ RefCart(_Cart, _DGVcart).ToString("0.00")}";
            _ItemCode = 0;
            _TxtCode.Clear();
            _TxtQty.Value = 1;
            _TxtCode.Focus();
            _Device = "";
        }

        public static void SaveAsExcel(DataGridView DGV, string FName, string[] Headers)
        {
            if (DGV.DataSource != null)
            {
                SaveFileDialog savefile = new SaveFileDialog
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*",
                    FileName = FName
                };
                var res = savefile.ShowDialog();
                if (res == DialogResult.OK)
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
                savefile.Dispose();
            }
        }

        public static void IssueItem(Dictionary<uint, decimal> _Cart, bool Ispecial = false)
        {
            List<BusinessItem> items = new List<BusinessItem>();
            decimal tot = 0;
            if (_Cart.Count > 0)
            {
                foreach (var s in _Cart)
                {
                    tot += client.ps.Live.Items[s.Key].outPrice;
                    items.Add(new BusinessItem { itemID = s.Key, Quantity = s.Value, Value = tot, Seller = user.ID });
                }
                client.Sale(new BasicSale { items = items, date = DateTime.Now, total = tot, SaleID = 0, UserID = user.UserID, special = Ispecial });
                _Cart.Clear();
            }
            else
            {
                MessageBox.Show("Cart Is Empty!\nPlease Add Items To Issue!", "LanakaStocks > Empty Cart!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void RefundItem(uint SaleID, Dictionary<uint, float> _LstItems, bool Ispecial = false)
        {
            List<BusinessItem> items = new List<BusinessItem>();
            decimal tot = 0;
            if (_LstItems.Count > 0)
            {
                foreach (var s in _LstItems)
                {
                    tot += client.ps.Live.Items[s.Key].outPrice;
                    items.Add(new BusinessItem { itemID = s.Key, Quantity = (decimal)s.Value, Value = tot, Seller = user.ID });
                }
                client.RefundItem(new BasicSale { items = items, date = DateTime.Now, total = tot, SaleID = SaleID, UserID = user.UserID, special = false });
                _LstItems.Clear();
            }
            else
            {
                MessageBox.Show("List Is Empty!\nPlease Add Items To Refund!", "LanakaStocks > Empty List!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class FormHandle
    {
        public void OpenForm(Control ParentC, Form childForm, FormBorderStyle fStyle, DockStyle dockStyle)
        {
            childForm.TopLevel = false;
            childForm.Location = new Point(0, 0);
            childForm.FormBorderStyle = fStyle;
            childForm.Dock = dockStyle;
            ParentC.Controls.Add(childForm);
            ParentC.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
