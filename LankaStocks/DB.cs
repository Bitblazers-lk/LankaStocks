using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static LankaStocks.Core;

namespace LankaStocks.DataBases
{
    public abstract class DB
    {
        public ulong LastUpdate = 10U;
        public ulong LastSave = 10U;



        [NonSerialized]
        public static bool IsBusy = false;
        [NonSerialized]
        public string FileName;

        public string DBName;



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
                        IsBusy = false;
                        SaveBinary();
                        IsBusy = true;
                        Log("@DB saved new empty DataBase");
                    }
                    else
                    {
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




    public class DBPeople : DB
    {
        public Dictionary<uint, Vendor> Vendors;
        public Dictionary<uint, User> Users;
        public Dictionary<uint, Person> OtherPeople;
    }

    public class DBLive : DB //Live database
    {
        public Dictionary<uint, Item> Items; //Stock item pool
        public decimal Cashier = 0M;

        public DBSession Session;
    }

    public class DBHistory : DB
    {
        public List<string> Sessions;
        public IDMachine IdMachine;
    }


    public class DBSession : DB
    {
        public DateTime sessionBegin;
        public DateTime sessionEnd;

        public Dictionary<uint, BasicSale> Sales;
        public Dictionary<uint, StockIntake> StockIntakes;

    }


}
