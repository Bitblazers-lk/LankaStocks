using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks
{
    public class DB
    {
        public string name;
        public DateTime date;
    }


    public class DBPersons : DB
    {
        public Dictionary<uint, Vendor> Vendors;
        public Dictionary<uint, User> Users;
        public Dictionary<uint, Person> people;
    }

    public class DBStock : DB
    {
        public Dictionary<uint, Item> Items; //Stock item pool
        public decimal Cashier = 0M;
    }

    public class DBHistory : DB
    {

    }

}
