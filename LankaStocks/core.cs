using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using LankaStocks.DataBases;
using System.Windows.Forms;
using LankaStocks.UIForms;

namespace LankaStocks
{
    public static class Core
    {
        #region DataBases
        public static DBLive Live;
        public static DBPeople People;

        public static DBHistory History;

        public static DBSettings Settings;

        public static DBSession Session => Live.Session;
        public static Dictionary<uint, BasicSale> Sales => Live.Session.Sales;
        public static Dictionary<uint, StockIntake> StockIntakes => Live.Session.StockIntakes;

        #endregion

        #region Loging
        public static void Log(string s)
        {
            string L = TimeStamp + s + Environment.NewLine;
            Console.WriteLine(L);

            new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(LogWriteFile)).Start(L);

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
            Log($"!!! Error {ex.ToString()} \t {note} \t {ex.Message} \t source : {ex.Source};\t Inner : {ex.InnerException?.ToString()} {ex.InnerException?.Message}; \n @{ex.StackTrace} \n Inner @{ex.InnerException?.StackTrace}");

        }
        public static string TimeStamp => $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}\t";

        #endregion

        public static void Initialize()
        {
            {
                bool isFirstRun = !File.Exists(DB.LogPath);
                if (isFirstRun)
                {
                    File.AppendAllText(DB.LogPath, $"Created new Data Base on {DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day} \n");
                }

                Live = (DBLive)new DBLive() { DBName = "DBLive", FileName = DB.DBPath + "DBLive.db" }.LoadBinary(isFirstRun);
                People = (DBPeople)new DBPeople() { DBName = "DBPeople", FileName = DB.DBPath + "DBPeople.db" }.LoadBinary(isFirstRun);
                History = (DBHistory)new DBHistory() { DBName = "DBHistory", FileName = DB.DBPath + "DBHistory.db" }.LoadBinary(isFirstRun);
                Settings = (DBSettings)new DBSettings() { DBName = "DBSettings", FileName = DB.DBPath + "DBSettings.db" }.LoadBinary(isFirstRun);

                Statics.ReCalculate();
            }

        }

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
