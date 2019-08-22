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
using System.Drawing;

namespace LankaStocks
{
    public static class Core
    {
        #region Vars

        public static bool IsInitialized = false;

        public static BaseServer Svr;

        public static BaseClient client;
        public static _Remote.DBs RemoteDBs;

        public static Random random = new Random();

        public static System.Threading.Thread CLIThread;
        //public static DBSession Session => Live.Session;
        //public static Dictionary<uint, BasicSale> Sales => Live.Session.Sales;
        //public static Dictionary<uint, StockIntake> StockIntakes => Live.Session.StockIntakes;

        #endregion


        public static void Initialize()
        {
            IsInitialized = true;
            Log("Lanka Stocks - Mahinda Rapaksha College");
            client = (BaseClient)new IntergratedClient();
            client.Initialize();

            RemoteDBs = new _Remote.DBs();

            //Testing....

            //Set DateTime object
            RemoteDBs.Session.sessionBegin.Set(new DateTime(2000, 6, 8));

            //Get it back
            Log(RemoteDBs.Session.sessionBegin.Get.ToString());

            //Set whole variable. (OK for any data type)
            RemoteDBs.Session.Sales.Set(new Dictionary<uint, BasicSale>() { { 1U, new BasicSale() { SaleID = 1U } }, { 2U, new BasicSale() { SaleID = 2U } }, { 3U, new BasicSale() { SaleID = 3U } } });

            Log("\n Visualize \n");
            Log(VisualizeObj(RemoteDBs.Session.Sales.Get));

            Log("\n Add to Dic \n");
            RemoteDBs.Session.Sales.Add(4, new BasicSale() { SaleID = 4U, buyerNote = "I'm added", special = true });

            Log("\n Visualize \n");
            Log(VisualizeObj(RemoteDBs.Session.Sales.Get));

            Log("\n Remove from Dic \n");
            RemoteDBs.Session.Sales.Remove(3);

            Log("\n Visualize \n");
            Log(VisualizeObj(RemoteDBs.Session.Sales.Get));

            Log("\n Set Dic item \n");
            RemoteDBs.Session.Sales.Set(4, new BasicSale() { SaleID = 4U, buyerNote = "I'm added and then changed", special = false, date = DateTime.Now });

            Log("\n Visualize \n");
            Log(VisualizeObj(RemoteDBs.Session.Sales.Get));


            //Settings

            //Set color (You can use commonSettings.Get too)
            //RemoteDBs.Settings.commonSettings.GetSet.BackColor = System.Drawing.Color.Aqua;
            //Get it back (You can use commonSettings.Set too)
            Log(RemoteDBs.Settings.commonSettings.GetSet.BackColor.ToString());

            Bills.SetHeaderBeginFont(new Font("Arial", 15));
            Bills.SetFont(new Font("Arial", 11));

            Bills.SetHeaderBegin(RemoteDBs.Settings.billSetting.Get.H1, RemoteDBs.Settings.billSetting.Get.H2, RemoteDBs.Settings.billSetting.Get.H3);
            Bills.SetHeaderEnd(RemoteDBs.Settings.billSetting.Get.E1, RemoteDBs.Settings.billSetting.Get.E2, RemoteDBs.Settings.billSetting.Get.E3);

            Log("Initialized");

            CLIThread = new System.Threading.Thread(new System.Threading.ThreadStart(CLIProgram)) { Name = "CLIProgram", Priority = System.Threading.ThreadPriority.Lowest };
            CLIThread.Start();
        }

        #region Loging
        public static void Log(string s)
        {
            string L = TimeStamp + s;// + "\n";
            Console.WriteLine(L);

            ThreadLogToFile(L + Environment.NewLine);

        }

        public static string Prompt(string s)
        {
            Console.WriteLine(s);
            return Console.ReadLine();
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

        public static string VisualizeObj(dynamic obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
        }


        private static void CLIProgram()
        {
            Begin:


            string s = Prompt("\n \n Enter Command").ToLower();
            string[] A = s.Split(' ');

            switch (A[0])
            {
                case "list":
                    switch (A[1])
                    {
                        case "users":
                            Log(VisualizeObj(RemoteDBs.People.Users.Get));
                            break;

                        case "vendors":
                            Log(VisualizeObj(RemoteDBs.People.Vendors.Get));
                            break;

                        case "otherpeople":
                            Log(VisualizeObj(RemoteDBs.People.OtherPeople.Get));
                            break;

                        case "items":
                            Log(VisualizeObj(RemoteDBs.Live.Items.Get));
                            break;
                        default:
                            break;
                    }
                    break;

                case "fix":
                    switch (A[1])
                    {
                        case "vendors":
                            foreach (var vend in Core.Svr.People.Vendors.Values)
                            {
                                vend.supplyingItems = new List<uint>();
                            }
                            break;
                        default:
                            break;
                    }


                    break;
                default:
                    break;
            }


            goto Begin;
        }


        #endregion


        public static void Shutdown()
        {
            //Save everything
            client.Shutdown();
            CLIThread.Abort();
            Log("Press Enter to Exit");
            Application.Exit();

        }
    }

    public static class Forms
    {
        public static List<string> FrmList = new List<string>();
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
        public static FrmQuickSale frmQuickSale;
        public static FrmRefund frmRefund;
        public static FrmCharts frmCharts;
        public static FrmEditQty frmEditQty;
    }
}
