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

    //TODO: ගැනුම්
    [Serializable]
    public class StockIntake : Record
    {
        public uint IntakeID;

        public uint vendorID;
        public List<Item> items;

        public Transaction trans;


    }

    //TODO: quick sale form
    [Serializable]
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

    //TODO: Complex sale with transaction UserControl
    [Serializable]
    public class SpecialSale : BasicSale
    {
        public Transaction transaction;

    }
}
