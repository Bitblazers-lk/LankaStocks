using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks
{
    public class Transaction
    {
        public uint ID;

        public decimal total;
        public decimal payed;
        public decimal Liability;

        public Types type;
        public uint User; //First party
        public uint SecondParty;

        public DateTime date;
        public string confirmation;
        public string note;

        public enum Types : byte
        {
            StockIntake,    //තොග ගැනීම - user <> vendor
            SpecialSale,   //විකිණීම - user <> buyer
            CashierRefund,//මුදල් පොතට office එකෙන් මුදල් ලැබීම. - user <> Office person
            Clearance,   //දවස අවසානයේ මුදල් ගෙවීම. - user <> Office person
            Summary,    //Reports - null <> null
            dispose,   // user <> null
            other     //user <> null - note required

        }


        public uint OfficePersonID = 2U;
    }
}
