using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using LankaStocks.DataBases;
using System.Windows.Forms;
using LankaStocks.UIForms;
using LankaStocks.Networking;
using System.Runtime.InteropServices;

namespace LankaStocks
{
    public static class Core
    {
        #region Vars

        public static BaseClient client;

        public static Random random = new Random();
        //public static DBSession Session => Live.Session;
        //public static Dictionary<uint, BasicSale> Sales => Live.Session.Sales;
        //public static Dictionary<uint, StockIntake> StockIntakes => Live.Session.StockIntakes;

        #endregion


        public static void Initialize()
        {
            Log("Lanka Stocks - Mahinda Rapaksha College");
            client = (BaseClient)new IntergratedClient();
            client.Initialize();
        }

        #region Loging
        public static void Log(string s)
        {
            string L = TimeStamp + s;// + "\n";
            Console.WriteLine(L);

            ThreadLogToFile(L + Environment.NewLine);

        }

        private static void ThreadLogToFile(string L)
        {
            new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(LogWriteFile)) { Name = "WriteFile", IsBackground = true, Priority = System.Threading.ThreadPriority.Lowest }.Start(L);
        }

        private static bool isLogFileBusy = false;
        private static void LogWriteFile(object o)
        {
            string s = (string)o;
            try
            {
                while (isLogFileBusy)
                    System.Threading.Thread.Sleep(100);

                isLogFileBusy = true;
                File.AppendAllText(DB.LogPath, s);
                isLogFileBusy = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot write log file - Error {ex.ToString()} \t {ex.Message} \t source : {ex.Source};\t Inner : {ex.InnerException?.ToString()} {ex.InnerException?.Message}; \n @{ex.StackTrace} \n Inner @{ex.InnerException?.StackTrace}");
            }
        }

        public static void LogErr(Exception ex, string note = "")
        {
            Log(ErrorStamp(ex, note));

        }

        public static string ErrorStamp(Exception ex, string note)
        {
            return $"!!! Error {ex.ToString()} \t {note} \t {ex.Message} \t source : {ex.Source};\t Inner : {ex.InnerException?.ToString()} {ex.InnerException?.Message}; \n @{ex.StackTrace} \n Inner @{ex.InnerException?.StackTrace}";
        }

        public static string TimeStamp => $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}\t";

        #endregion


        public static void Shutdown()
        {
            //Save everything
            Application.Exit();
        }


    }


    public static class Forms
    {
        public static Login login;
        public static Dashboard dashboard;
        public static AddData addData;
        public static AddItems addItems;
        public static ItemIntake itemIntake;
        public static FrmanageData frmanageData;
        public static FrmanageItems frmanageItems;
        public static FrmSales frmSales;
        public static FrmTransaction frmTransaction;
        public static FrmSettings frmSettings;
    }
}
