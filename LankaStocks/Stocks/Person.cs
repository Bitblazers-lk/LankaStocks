using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks
{
    //TODO: 3 adding forms for persons
    [Serializable]
    public class Person
    {
        public uint personID;
        public string name;
        public string details;
        public string contactInfo;

        public Transaction summary;
    }

    [Serializable]
    public class User : Person
    {
        public uint userID;
        public string userName;
        public string pass;
        public bool isAdmin;

    }

    [Serializable]
    public class Vendor : Person
    {
        public uint vendorID;
        public string BusinessInfo;

        public List<uint> supplyingItems;//<ItemID>

    }
}
