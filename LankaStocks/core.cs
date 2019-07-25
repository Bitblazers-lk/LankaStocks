using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LankaStocks.DataBases;

namespace LankaStocks
{
    public static class Core
    {
        //DataBases
        public static DBLive Live;
        public static DBPeople People;

        public static DBHistory History;

        public static DBSession Session => Live.Session;
        public static Dictionary<uint, BasicSale> Sales => Live.Session.Sales;
        public static Dictionary<uint, StockIntake> StockIntakes => Live.Session.StockIntakes;

        public static void Log(string s)
        {
            string L = TimeStamp + s;
            Console.WriteLine(L);
        }
        public static void LogErr(Exception ex, string note = "")
        {
            String L = $"{TimeStamp} !!! Error {ex.ToString()} \t {note} \t {ex.Message} \t source : {ex.Source};\t Inner : {ex.InnerException?.ToString()} {ex.InnerException?.Message}; \n @{ex.StackTrace} \n Inner @{ex.InnerException?.StackTrace}";
            Console.WriteLine(L);
        }
        public static string TimeStamp => $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}\t";
    }
}
