using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks
{
    public interface IRecord
    {

    }

    [Serializable]
    public class StockIntake : IRecord
    {
        public uint IntakeID;
        public uint vendorID;
        public Item item;

        public Transaction trans;
    }


    [Serializable]
    public class BasicSale : IRecord
    {
        public uint SaleID;
        public uint UserID;

        public List<BusinessItem> items;

        public DateTime date;
        public decimal total;

        public bool special = false;

        public void CalculateTotal()
        {
            total = 0;

            foreach (var item in items)
            {
                total += item.Quantity * item.Value;
            }

        }
    }

    [Serializable]
    public class SpecialSale : BasicSale
    {
        public string buyerNote;
        public Transaction transaction;

        public SpecialSale()
        {
            special = true;
        }
    }
}
