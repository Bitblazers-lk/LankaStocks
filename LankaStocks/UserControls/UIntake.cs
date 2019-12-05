using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LankaStocks.Core;
using LankaStocks.Shared;

namespace LankaStocks.UserControls
{
    public partial class UIntake : UserControl
    {
        public UIntake()
        {
            InitializeComponent();
            uiExcel1.Save.Click += Save_Click;
            uiExcel2.Save.Click += Save_Click1;
        }

        private void Save_Click1(object sender, EventArgs e)
        {
            RepeatedFunctions.SaveAsExcel(DGVit, $"Sold Items.csv", new string[] { "Item ID", "Name", "Qty", "Total" });
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (CbAll.Checked) RepeatedFunctions.SaveAsExcel(DGVin, $"Sales All.csv", new string[] { "Sale ID", "Date", "Total Items", "Total" });
            else RepeatedFunctions.SaveAsExcel(DGVin, $"Sales {datepick.Value.ToString("yyyyMMdd")}.csv", new string[] { "Sale ID", "Date", "Total Items", "Total" });
        }

        void GetHis(bool all, DateTime Date, string ID)
        {
            var Data = new List<SaleHis>();
            if (all)
            {
                foreach (var item in client.ps.History.Sessions)
                {
                    foreach (var s in client.ps.History.ViewSession(item).Sales)
                    {
                        if (s.Value.SaleID.ToString().Contains(ID))
                        {
                            s.Value.CalculateTotal();
                            Data.Add(new SaleHis { Sale_ID = s.Value.SaleID, Date = s.Value.date, Total_Items = s.Value.items.Count, Total = s.Value.total });
                        }
                    }
                }
            }
            else
            {
                var d = client.ps.History.ViewSession(Date);
                if (d != null)
                {
                    foreach (var s in d.Sales)
                    {
                        if (s.Value.SaleID.ToString().Contains(ID))
                        {
                            s.Value.CalculateTotal();
                            Data.Add(new SaleHis { Sale_ID = s.Value.SaleID, Date = s.Value.date, Total_Items = s.Value.items.Count, Total = s.Value.total });
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"No Records Found On {Date.Date}.", "LankaStocks > Sale History!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            DGVin.DataSource = Data;
        }

        void GetItems(string ID)
        {
            var Data = new List<SaleItm>();
            foreach (var item in client.ps.History.Sessions)
            {
                foreach (var s in client.ps.History.ViewSession(item).Sales)
                {
                    if (s.Value.SaleID.ToString().Contains(ID))
                    {
                        foreach (var i in s.Value.items)
                        {
                            Data.Add(new SaleItm { Item_ID = i.itemID, Name = client.ps.Live.Items[i.itemID].name, Qty = i.Quantity, Total = (i.Quantity * client.ps.Live.Items[i.itemID].outPrice) });
                        }
                    }
                }
            }
            DGVit.DataSource = Data;
        }

        private void datepick_ValueChanged(object sender, EventArgs e)
        {
            GetHis(CbAll.Checked, datepick.Value, Txtno.Text);
        }

        private void CbAll_CheckedChanged(object sender, EventArgs e)
        {
            GetHis(CbAll.Checked, datepick.Value, Txtno.Text);
        }

        private void Txtno_TextChanged(object sender, EventArgs e)
        {
            GetHis(CbAll.Checked, datepick.Value, Txtno.Text);
        }

        private void DGVin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGVin.CurrentCell != null && DGVin.Rows?[DGVin.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString() != null)
            {
                GetItems(DGVin.Rows?[DGVin.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString());
            }
        }

        private void BtnRef_Click(object sender, EventArgs e)
        {
            GetHis(CbAll.Checked, datepick.Value, Txtno.Text);
        }

        void GetRec_Data(DateTime Date)
        {
            var Data = new List<Rec_data>();
            var d = client.ps.History.ViewSession(Date);
            decimal Out = 0;
            decimal In = 0;
            if (d != null)
            {
                foreach (var item in client.ps.Live.Items)
                {
                    foreach (var sale in d.Sales)
                    {
                        foreach (var i in sale.Value.items)
                        {
                            if (item.Value.itemID == i.itemID)
                            {
                                Out += i.Quantity;
                            }
                        }
                    }
                    foreach (var sin in d.StockIntakes)
                    {
                        if (item.Value.itemID == sin.Value.item.itemID)
                        {
                            In += sin.Value.item.Quantity;
                        }
                    }
                    Data.Add(new Rec_data { Name = item.Value.name, IN = In, OUT = Out });
                }

            }
            else
            {
                MessageBox.Show($"No Records Found On {Date.Date}.", "LankaStocks > Sale History!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }

    public struct Rec_data
    {
        public string Name { get; set; }
        public decimal Begin_Balance { get; set; }
        public decimal IN { get; set; }
        public decimal OUT { get; set; }
        public decimal Final_Balance { get; set; }
        public decimal Total_Value { get; set; }
    }
}


