using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LankaStocks.Charts
{
    public partial class UICHNow : UserControl
    {
        public UICHNow()
        {
            InitializeComponent();           
            groupBox1.Controls.Add(ChartSales);
            ChartSales.Dock = DockStyle.Fill;

            groupBox2.Controls.Add(ChartCustomers);
            ChartCustomers.Dock = DockStyle.Fill;
        }
        CHSalesRealTime ChartSales = new CHSalesRealTime(5000, "Sales", false);
        CHSalesRealTime ChartCustomers = new CHSalesRealTime(5000, "Customers", false);
    }
}
