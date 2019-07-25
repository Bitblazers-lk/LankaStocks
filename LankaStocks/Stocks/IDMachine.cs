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
        public uint PersonID = 100U;
        public uint ItemID = 10U;

        public uint IntakeID = 1U;
        public uint SaleID = 1U;

        public uint TransactionID = 100U;
    }
}
