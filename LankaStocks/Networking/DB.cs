using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using LankaStocks;
using static LankaStocks.Core;
using LankaStocks.Setting;
using System.Reflection;
using System.Collections;
using LankaStocks.Networking;

namespace LankaStocks.DataBases
{
    [Serializable]
    public abstract class DB
    {

        public const string DBPath = "DB\\";
        public const string LogPath = "DB\\log.txt";
        public const string StampPath = "DB\\MRC.stamp";
        public const string HistoryPath = "DB\\History\\";


        public string DBName;
        public ulong LastUpdate = 10U;
        public ulong LastSave = 10U;



        [NonSerialized]
        public static bool IsBusy = false;
        [NonSerialized]
        public string FileName;

        public abstract void CreateNewDatabase();


        public void SaveBinary()
        {
            while (IsBusy)
                System.Threading.Thread.Sleep(100);

            if (LastUpdate == LastSave)
                return;

            IsBusy = true;



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

            if (LastUpdate != LastSave) { IsBusy = false; SaveBinary(); }


            System.IO.FileStream FS = null;
            try
            {
                if (!File.Exists(FileName))
                {
                    Log($"Database {DBName} in {FileName} not found.");

                    if (CreateNewIfNotFound)
                    {
                        LastUpdate++;
                        CreateNewDatabase();
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

        public void ForceSave()
        {
            LastUpdate++;
            SaveBinary();
        }

        /// <summary>
        /// returns DB from list  _ _ _ 
        /// Usage : DBName = DBName.DiscardChanges();
        /// </summary>
        public DB DiscardChanges() { LastUpdate = LastSave; return LoadBinary(); }



        public abstract (dynamic, MemberType) Resolve(string expr);
        // public abstract void SetDataMember(string expr, dynamic data);
        public void SetDataMember(string name, dynamic val)
        {
            // GetType().InvokeMember(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetField, Type.DefaultBinder, this, val);

            GetType().GetField(name).SetValue(this, val);
        }
        public dynamic GetDataMember(string name)
        {
            return GetType().GetField(name).GetValue(this);
        }

        public enum MemberType : byte { notFound, data, obj, array, list, dic }


        public virtual void Respond(Request req, ref Response resp)
        {
            var solv = Resolve(req.expr);
            switch ((Request.Command)req.command)
            {
                case Request.Command.get:

                    if (req.para == null) { solv.Item2 = MemberType.obj; }

                    resp.result = (byte)Response.Result.ok;

                    switch (solv.Item2)
                    {
                        case MemberType.notFound:
                            resp.result = (byte)Response.Result.notfound;
                            resp.obj = null;
                            resp.msg += $"{req.expr} not found";
                            break;


                        case MemberType.data:
                        case MemberType.obj:
                            try
                            {
                                resp.obj = solv.Item1;
                            }
                            catch (Exception)
                            {
                                resp.result = (byte)Response.Result.notfound;
                                resp.obj = null;
                                resp.msg += $"{req.expr} {solv.Item2.ToString()} member not found";
                            }
                            break;


                        case MemberType.array:
                            try
                            {
                                resp.obj = solv.Item1[req.para[0]];
                            }
                            catch (Exception)
                            {
                                resp.result = (byte)Response.Result.notfound;
                                resp.obj = null;
                                resp.msg += $"{req.expr}[{req.para[0]}] not found in {solv.Item2.ToString()} member";
                            }
                            break;


                        case MemberType.list:
                            try
                            {
                                var lst = (List<dynamic>)solv.Item1;
                                resp.obj = lst[(int)req.para[0]];
                            }
                            catch (Exception)
                            {
                                resp.result = (byte)Response.Result.notfound;
                                resp.obj = null;
                                resp.msg += $"{req.expr}[{req.para[0]}] not found in {solv.Item2.ToString()} member";
                            }
                            break;


                        case MemberType.dic:
                            var d = (IDictionary)solv.Item1;

                            if (d.Contains(req.para[0]))
                            {
                                resp.obj = d[req.para[0]];
                            }
                            else
                            {
                                resp.result = (byte)Response.Result.notfound;
                                resp.obj = null;
                                resp.msg += $"{req.expr}[{req.para[0]}] not found in {solv.Item2.ToString()} member";
                            }

                            break;


                        default:
                            break;
                    }
                    break;
                case Request.Command.set:

                    if (req.para == null || req.para.Length != 2) { solv.Item2 = MemberType.obj; }

                    resp.result = (byte)Response.Result.ok;

                    switch (solv.Item2)
                    {
                        case MemberType.notFound:
                            resp.result = (byte)Response.Result.notfound;
                            resp.msg += $"{req.expr} not found";
                            break;


                        case MemberType.data:
                        case MemberType.obj:
                            try
                            {
                                SetDataMember(req.expr, req.para[0]);
                            }
                            catch (Exception)
                            {
                                resp.result = (byte)Response.Result.notfound;
                                resp.obj = null;
                                resp.msg += $"{req.expr} {solv.Item2.ToString()} member not found";
                            }
                            break;



                        case MemberType.array:
                            try
                            {
                                solv.Item1[req.para[0]] = req.para[1];
                            }
                            catch (Exception)
                            {
                                resp.result = (byte)Response.Result.notfound;
                                resp.obj = null;
                                resp.msg += $"{req.expr}[{req.para[0]}] not found in {solv.Item2.ToString()} member";
                            }
                            break;


                        case MemberType.list:
                            try
                            {
                                var lst = (List<dynamic>)solv.Item1;
                                lst[(int)req.para[0]] = req.para[1];
                            }
                            catch (Exception)
                            {
                                resp.result = (byte)Response.Result.notfound;
                                resp.obj = null;
                                resp.msg += $"{req.expr}[{req.para[0]}] not found in {solv.Item2.ToString()} member";
                            }
                            break;


                        case MemberType.dic:
                            dynamic d = solv.Item1;
                            try
                            {
                                d[req.para[0]] = req.para[1];
                            }
                            catch (Exception)
                            {
                                resp.result = (byte)Response.Result.notfound;
                                resp.obj = null;
                                resp.msg += $"{req.expr}[{req.para[0]}] not found in {solv.Item2.ToString()} member";
                            }

                            break;


                        default:
                            break;
                    }


                    break;
                case Request.Command.add:
                    resp.result = (byte)Response.Result.ok;

                    switch (solv.Item2)
                    {
                        case MemberType.notFound:
                            resp.result = (byte)Response.Result.notfound;
                            resp.msg += $"{req.expr} not found";
                            break;



                        case MemberType.list:
                            var lst = (List<dynamic>)solv.Item1;
                            lst.Add(req.para[0]);

                            break;


                        case MemberType.dic:
                            dynamic d = solv.Item1;
                            try
                            {
                                d.Add(req.para[0], req.para[1]);
                            }
                            catch (System.ArgumentException)
                            {
                                resp.result = (byte)Response.Result.notfound;
                                resp.obj = null;
                                resp.msg += $"{req.expr}[{req.para[0]}] already exists in dictionary";
                            }
                            catch (Exception ex)
                            {
                                resp.result = (byte)Response.Result.notfound;
                                resp.obj = null;
                                resp.msg += $"Error {Core.ErrorStamp(ex, "Dictionary add error")}";
                            }
                            break;


                        default:
                            resp.result = (byte)Response.Result.notfound;
                            resp.obj = null;
                            resp.msg += $"{req.expr}[{req.para[0]}] not found in {solv.Item2.ToString()} member";
                            break;
                    }
                    break;
                case Request.Command.rem:

                    resp.result = (byte)Response.Result.ok;

                    switch (solv.Item2)
                    {
                        case MemberType.notFound:
                            resp.result = (byte)Response.Result.notfound;
                            resp.msg += $"{req.expr} not found";
                            break;



                        case MemberType.list:
                            var lst = (List<dynamic>)solv.Item1;
                            if (req.para.Count() == 1) { lst.RemoveAt(req.para[0]); }
                            else if (req.para.Count() > 1) { lst.Remove((object)req.para[1]); }
                            else
                            {
                                resp.result = (byte)Response.Result.notfound;
                                resp.obj = null;
                                resp.msg += $"{req.expr} wrong para.count for {solv.Item2.ToString()} member";
                            }
                            break;


                        case MemberType.dic:
                            dynamic d = solv.Item1;
                            try
                            {
                                d.Remove(req.para[0]);
                            }
                            catch (Exception ex)
                            {
                                resp.result = (byte)Response.Result.notfound;
                                resp.obj = null;
                                resp.msg += $"Error {Core.ErrorStamp(ex, "Dictionary add error")}";
                            }
                            break;


                        default:
                            resp.result = (byte)Response.Result.notfound;
                            resp.obj = null;
                            resp.msg += $"{req.expr}[{req.para[0]}] not found in {solv.Item2.ToString()} member";
                            break;
                    }
                    break;



                default:
                    resp.result = (byte)Response.Result.unknown;
                    resp.msg += "\n @DB cannot switch your command";
                    break;
            }

        }

    }

    [Serializable]
    public class DBPeople : DB
    {
        public Dictionary<uint, Vendor> Vendors;
        public Dictionary<uint, User> Users;
        public Dictionary<uint, Person> OtherPeople;

        public override void CreateNewDatabase()
        {
            Vendors = new Dictionary<uint, Vendor>();
            Users = new Dictionary<uint, User>();
            OtherPeople = new Dictionary<uint, Person>();

            Users.Add(100, new User() { userName = "amanda", ID = 100, isAdmin = true, name = "Amanda Nanda", pass = "200" });
            Users.Add(200, new User() { userName = "nimal", ID = 200, isAdmin = false, name = "Nimal Bimalka", pass = "123" });
        }

        public override (dynamic, MemberType) Resolve(string expr)
        {
            switch (expr)
            {
                case "Vendors":
                    return (Vendors, MemberType.dic);
                case "Users":
                    return (Users, MemberType.dic);
                case "OtherPeople":
                    return (OtherPeople, MemberType.dic);
                default:
                    return (null, MemberType.notFound);
            }
        }

        //public override void SetDataMember(string expr, dynamic data)
        //{
        //    //No data members here
        //}
    }

    [Serializable]
    public class DBLive : DB //Live database
    {
        public Dictionary<uint, Item> Items; //Stock item pool
        public Dictionary<uint, decimal> Cashiers;

        public DBSession Session;

        public IDMachine IdMachine;


        public override void CreateNewDatabase()
        {
            //TODO: Add cashiers for users
            Cashiers = new Dictionary<uint, decimal>();
            Items = new Dictionary<uint, Item>
            {
                { 10, new Item { itemID = 10, inPrice = 100, outPrice = 125, name = "Box", Quantity = 100, vendors=new List<uint>(){0} } },
                { 11, new Item { itemID = 11, inPrice = 90, outPrice = 100, name = "Box1", Quantity = 100,  vendors=new List<uint>(){0} } }
            };


            IdMachine = new IDMachine();


            Session = new DBSession();
            Session.CreateNewDatabase();

        }

        public override (dynamic, MemberType) Resolve(string expr)
        {
            switch (expr)
            {
                case "Items":
                    return (Items, MemberType.dic);
                case "Cashiers":
                    return (Cashiers, MemberType.dic);
                case "Session":
                    return (Session, MemberType.obj);
                case "IdMachine":
                    return (IdMachine, MemberType.obj);
                default:
                    return (null, MemberType.notFound);
            }
        }

        //public override void SetDataMember(string expr, dynamic data)
        //{
        //    switch (expr)
        //    {
        //        case "Session":
        //            Session = data;
        //            break;
        //        default:
        //            break;
        //    }

        //}
    }

    [Serializable]
    public class DBHistory : DB
    {
        public List<string> Sessions;

        public override void CreateNewDatabase()
        {
            Sessions = new List<string>();
        }
        public override (dynamic, MemberType) Resolve(string expr)
        {
            switch (expr)
            {
                //TODO: Read history db from disk and send that. not path
                case "Sessions":
                    return (Sessions, MemberType.list);
                default:
                    return (null, MemberType.notFound);
            }
        }

        //public override void SetDataMember(string expr, dynamic data)
        //{
        //    switch (expr)
        //    {
        //        case "IdMachine":
        //            IdMachine = data;
        //            break;
        //        default:
        //            break;
        //    }

        //}
    }

    [Serializable]
    public class DBSession : DB
    {
        public DateTime sessionBegin;
        public DateTime sessionEnd;

        public Dictionary<uint, BasicSale> Sales;
        public Dictionary<uint, StockIntake> StockIntakes;

        public override void CreateNewDatabase()
        {
            sessionBegin = DateTime.Now;
            Sales = new Dictionary<uint, BasicSale>();
            StockIntakes = new Dictionary<uint, StockIntake>();
        }

        public override (dynamic, MemberType) Resolve(string expr)
        {
            switch (expr)
            {
                case "sessionBegin":
                    return (sessionBegin, MemberType.data);
                case "sessionEnd":
                    return (sessionEnd, MemberType.data);
                case "Sales":
                    return (Sales, MemberType.dic);
                case "StockIntakes":
                    return (StockIntakes, MemberType.dic);
                default:
                    return (null, MemberType.notFound);
            }
        }

        //public override void SetDataMember(string expr, dynamic data)
        //{
        //    switch (expr)
        //    {
        //        case "sessionBegin":
        //            sessionBegin = (DateTime)data;
        //            break;
        //        case "sessionEnd":
        //            sessionEnd = (DateTime)data;
        //            break;
        //        default:
        //            break;
        //    }

        //}
    }

    [Serializable]
    public class DBSettings : DB
    {
        public BillSettings billSetting;
        public CommonSettings commonSettings;

        public override void CreateNewDatabase()
        {
            billSetting = new BillSettings
            {
                H1 = "...LankaStocks...",
                H2 = "Tel : 0123456789",
                H3 = "...<>...",
                E1 = "..!Thank You!..",
                E2 = "...Come Again...",
                E3 = "...<>...",
                Perview = false,
                PrintBill = false
            };
            commonSettings = new CommonSettings
            {
                MenuColor = Color.FromArgb(91, 11, 31),
                BackColor = Color.FromArgb(10, 5, 10),
                FontColor = Color.FromKnownColor(KnownColor.Orange),
                ItemColor = Color.FromKnownColor(KnownColor.WindowFrame),
                OpenAtStat = false,
                ImagePath = null,
                Font = new Font("Comic Sans MS", 9.75f),
                WarnWhen = 10.00M
            };
        }

        public override (dynamic, MemberType) Resolve(string expr)
        {
            switch (expr)
            {
                case "billSetting":
                    return (billSetting, MemberType.obj);
                case "commonSettings":
                    return (commonSettings, MemberType.obj);
                default:
                    return (null, MemberType.notFound);
            }
        }

        //public override void SetDataMember(string expr, dynamic data)
        //{
        //    switch (expr)
        //    {
        //        case "sessionBegin":
        //            billSetting = data;
        //            break;
        //        case "sessionEnd":
        //            commonSettings = data;
        //            break;
        //        default:
        //            break;
        //    }

        //}
    }
}