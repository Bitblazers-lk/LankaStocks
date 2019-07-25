using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks
{
    public interface Record
    {

    }

    public class StockIntake : Record
    {
        public uint IntakeID;

        public uint vendorID;
        public List<Item> items;

        public Transaction trans;


    }


    public class BasicSale : Record
    {
        public uint SaleID;
        public uint UserID;

        public List<Item> items;

        public string buyerNote;
        public DateTime date;
        public decimal total;

        public bool special = false;

    }

    public class SpecialSale : BasicSale
    {
        public Transaction transaction;

    }
}
