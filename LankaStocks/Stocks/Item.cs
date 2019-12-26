using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks
{
    [Serializable]
    public class Item
    {
        public uint itemID = 0;
        public string Barcode;

        public string name;
        public uint vendor;

        public decimal inPrice = 0M;
        public decimal outPrice = 0M;

        public decimal Quantity = 0;

        public uint Alternative = 0; // Switch after this item is over

        public Item Clone()
        {
            return new Item() { Alternative = Alternative, Barcode = Barcode, inPrice = inPrice, itemID = itemID, name = name, outPrice = outPrice, Quantity = Quantity, vendor = vendor };
        }
    }


    [Serializable]
    public class BusinessItem
    {
        public uint itemID = 0;
        public uint Seller;
        public uint Buyer;
        public decimal Value;//Money/Price
        public decimal Quantity = 0;

    }
}
