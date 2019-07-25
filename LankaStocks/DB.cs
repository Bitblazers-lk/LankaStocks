using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static LankaStocks.Core;

namespace LankaStocks.DataBases
{
    [Serializable]
    public abstract class DB
    {

        public const string DBPath = "DB\\";
        public const string LogPath = "DB\\log.txt";
        public const string HistoryPath = "DB\\History\\";


        public string DBName;
        public ulong LastUpdate = 10U;
        public ulong LastSave = 10U;



        [NonSerialized]
        public static bool IsBusy = false;
        [NonSerialized]
        public string FileName;

        public abstract void CreateNew();


        public void SaveBinary()
        {
            while (IsBusy)
                System.Threading.Thread.Sleep(100);

            IsBusy = true;

            if (LastUpdate == LastSave)
                return;

            ulong changes = LastUpdate - LastSave;
            LastSave = LastUpdate;


            System.IO.FileStream fs = null;
            try
            {
                fs = new System.IO.FileStream(FileName, System.IO.FileMode.OpenOrCreate);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(fs, this);

                Log($"@DB Save succesful. {changes} changes in {DBName}");

                fs.Close();
            }
            catch (Exception ex)
            {
                LogErr(ex, $"@DB Failed to save {DBName}");

                try
                {
                    fs.Close();
                }
                catch (Exception)
                {
                }
            }

            IsBusy = false;
        }


        public DB LoadBinary(bool CreateNewIfNotFound = false)
        {
            while (IsBusy)
                System.Threading.Thread.Sleep(100);

            IsBusy = true;

            if (LastUpdate != LastSave)
                SaveBinary();



            System.IO.FileStream FS = null;
            try
            {
                if (!File.Exists(FileName))
                {
                    Log($"Database {DBName} in {FileName} not found.");

                    if (CreateNewIfNotFound)
                    {
                        LastUpdate++;
                        CreateNew();
                        IsBusy = false;
                        SaveBinary();
                        IsBusy = true;
                        Log("@DB saved new empty DataBase");
                    }
                    else
                    {
                        IsBusy = false;
                        return null;
                    }
                }


                Log($"@DB {DBName} File opening...");

                FS = new System.IO.FileStream(FileName, System.IO.FileMode.Open);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                DB newDB = (DB)bf.Deserialize(FS);
                FS.Close();

                IsBusy = false;


                Log($"@DB {DBName} loading success.");
                newDB.FileName = FileName;

                return newDB;
            }
            catch (Exception ex)
            {
                LogErr(ex, $"@DB Failed to save {DBName}");

                try
                {
                    FS.Close();
                }
                catch (Exception)
                {
                }
            }

            IsBusy = false;
            return null;
        }



    }

    [Serializable]
    public class DBPeople : DB
    {
        public Dictionary<uint, Vendor> Vendors;
        public Dictionary<uint, User> Users;
        public Dictionary<uint, Person> OtherPeople;

        public override void CreateNew()
        {
            Vendors = new Dictionary<uint, Vendor>();
            Users = new Dictionary<uint, User>();
            OtherPeople = new Dictionary<uint, Person>();

            Users.Add(100, new User() { userName = "amanda", userID = 100, isAdmin = true, name = "Amanda Nanda", pass = "200" });
            Users.Add(200, new User() { userName = "nimal", userID = 200, isAdmin = false, name = "Nimal Bimalka", pass = "123" });
        }
    }

    [Serializable]
    public class DBLive : DB //Live database
    {
        public Dictionary<uint, Item> Items; //Stock item pool
        public decimal Cashier = 0M;

        public DBSession Session;

        public override void CreateNew()
        {
            Items = new Dictionary<uint, Item>();
            Session = new DBSession();
            Session.CreateNew();
        }
    }

    [Serializable]
    public class DBHistory : DB
    {
        public List<string> Sessions;
        public IDMachine IdMachine;

        public override void CreateNew()
        {
            Sessions = new List<string>();
            IdMachine = new IDMachine();
        }
    }


    [Serializable]
    public class DBSession : DB
    {
        public DateTime sessionBegin;
        public DateTime sessionEnd;

        public Dictionary<uint, BasicSale> Sales;
        public Dictionary<uint, StockIntake> StockIntakes;

        public override void CreateNew()
        {
            sessionBegin = DateTime.Now;
            Sales = new Dictionary<uint, BasicSale>();
            StockIntakes = new Dictionary<uint, StockIntake>();
        }

    }


}
