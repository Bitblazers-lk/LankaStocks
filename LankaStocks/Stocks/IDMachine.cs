using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks
{
    [Serializable]
    public class IDMachine
    {
        public uint PersonID = 0U;
        public uint ItemID = 10U;


        public uint VendorID = 0U;
        public uint UserID = 0U;

        public uint IntakeID = 0U;
        public uint SaleID = 0U;

        public uint TransactionID = 100U;
    }
}
