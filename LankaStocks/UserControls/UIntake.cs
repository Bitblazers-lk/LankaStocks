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

        private void Datepick_ValueChanged(object sender, EventArgs e)
        {
            GetRec_Data(datepick.Value);
        }

        private void CbAll_CheckedChanged(object sender, EventArgs e)
        {
            //GetHis(CbAll.Checked, datepick.Value, Txtno.Text);
        }

        private void Txtno_TextChanged(object sender, EventArgs e)
        {
            // GetHis(CbAll.Checked, datepick.Value, Txtno.Text);
        }

        private void DGVin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGVin.CurrentCell != null && DGVin.Rows?[DGVin.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString() != null)
            {
                //GetItems(DGVin.Rows?[DGVin.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString());
            }
        }

        private void BtnRef_Click(object sender, EventArgs e)
        {
            GetRec_Data(datepick.Value);
        }

        void GetRec_Data(DateTime Date)
        {
            var Data = new List<Rec_data>();
            DataBases.DBSession d;
            if (Date.Date == DateTime.Now.Date) d = client.ps.Live.Session;
            else
                d = client.ps.History.ViewSession(Date);
            if (d != null)
            {
                foreach (var item in client.ps.Live.Items)
                {
                    decimal Out = 0;
                    decimal In = 0;
                    decimal Bbal = 0;
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
                    foreach (var bal in d.BeginingItems)
                    {
                        if (item.Value.itemID == bal.Value.itemID) Bbal = bal.Value.Quantity;
                    }

                    Data.Add(new Rec_data { Name = item.Value.name, Begin_Balance = Bbal, IN = In, OUT = Out, Final_Balance = Bbal + In - Out, Total_Value = item.Value.outPrice * (Bbal + In - Out) });
                }
                DGVin.DataSource = Data;

            }
            else
            {
                MessageBox.Show($"No Records Found On {Date.Date}.", "LankaStocks > Sale History!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void UIntake_Load(object sender, EventArgs e)
        {
            GetRec_Data(datepick.Value);
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


