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
using System.Globalization;
using LankaStocks.DataBases;

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
           // RepeatedFunctions.SaveAsExcel(DGVit, $"Sold Items.csv", new string[] { "Item ID", "Name", "Qty", "Total" });
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //    if (CbAll.Checked) RepeatedFunctions.SaveAsExcel(DGVin, $"Sales All.csv", new string[] { "Sale ID", "Date", "Total Items", "Total" });
            //    else RepeatedFunctions.SaveAsExcel(DGVin, $"Sales {datepick.Value.ToString("yyyyMMdd")}.csv", new string[] { "Sale ID", "Date", "Total Items", "Total" });
        }

        private void Datepick_ValueChanged(object sender, EventArgs e)
        {
            //  GetRec_Data(datepick.Value);
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
            // GetRec_Data(datepick.Value);
        }

        void GetRec_Data(DateTime Date)
        {
            var Data = new List<Rec_data>();
            DataBases.DBSession d;
            if (Date.Date == DateTime.Now.Date) d = client.ps.Live.Session;
            else
                d = DBHistory.ViewSession(Date);
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

        void GetRecM_Data(DateTime Date)
        {
            var Data = new List<Rec_data>();
            var DateList = client.ps.History.Sessions.Select(x => GetValidDate(x)).Where(a => a.Year == Date.Year && a.Month == Date.Month).ToList();
            if (DateTime.Now.Year == Date.Year && DateTime.Now.Month == Date.Month)
            {
                DateList.Add(DateTime.Now);
            }
            foreach (var item in client.ps.Live.Items)
            {
                decimal Out = 0;
                decimal In = 0;
                decimal Bbal = 0;
                foreach (var s in DateList)
                {

                    DataBases.DBSession d;
                    //if (Date.Year == DateTime.Now.Year && Date.Month == DateTime.Now.Month) d = client.ps.Live.Session;
                    //else
                    if (s.Date == DateTime.Now.Date) d = client.ps.Live.Session;
                    else d = DBHistory.ViewSession(s);

                    if (d != null)
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
                        if (s == DateList.Min())
                        {
                            foreach (var bal in d.BeginingItems)
                            {
                                if (item.Value.itemID == bal.Value.itemID) Bbal = bal.Value.Quantity;
                            }
                        }
                    }

                }
                Data.Add(new Rec_data { Name = item.Value.name, Begin_Balance = Bbal, IN = In, OUT = Out, Final_Balance = Bbal + In - Out, Total_Value = item.Value.outPrice * (Bbal + In - Out) });
            }
            DGVin.DataSource = Data;
        }

        private DateTime GetValidDate(string date)
        {
            if (DateTime.TryParseExact(date, "yyyyMM", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
            }
            else if (DateTime.TryParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
            }
            return result;
        }

        private void UIntake_Load(object sender, EventArgs e)
        {
            if (CBabm.Checked)
                GetMonths();
            else
                GetDates();
            if (CBabm.Checked) GetRecM_Data(GetValidDate(COMB.SelectedItem.ToString()));
            else GetRec_Data(GetValidDate(COMB.SelectedItem.ToString()));
        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void CBabm_CheckedChanged(object sender, EventArgs e)
        {
            if (CBabm.Checked)
                GetMonths();
            else
                GetDates();
        }

        void GetDates()
        {
            var lst = new List<string>();
            lst.AddRange(client.ps.History.Sessions);
            lst.Add(DateTime.Now.ToString("yyyyMMdd"));
            COMB.DataSource = lst;
        }
        void GetMonths()
        {
            var lst = new List<string>();
            lst.AddRange(client.ps.History.Sessions);
            lst.Add(DateTime.Now.ToString("yyyyMMdd"));
            var lstO = new List<string>();
            foreach (var s in lst)
            {
                string D = GetValidDate(s).ToString("yyyyMM");
                if (!lstO.Contains(D))
                    lstO.Add(D);
            }
            COMB.DataSource = lstO;
        }

        private void COMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBabm.Checked) GetRecM_Data(GetValidDate(COMB.SelectedItem.ToString()));
            else GetRec_Data(GetValidDate(COMB.SelectedItem.ToString()));
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


