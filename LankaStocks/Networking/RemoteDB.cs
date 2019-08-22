using LankaStocks.DataBases;
using LankaStocks.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LankaStocks.Core;

namespace LankaStocks._Remote
{
    public class DBs
    {
        public Live Live = new Live();
        public Session Session = new Session();
        public People People = new People();
        public History History = new History();
        public Settings Settings = new Settings();

    }

    public class Live : RemoteDB
    {
        public RemoteDic<uint, Item> Items = new RemoteDic<uint, Item>() { name = "Items", db = "Live" };
        public RemoteDic<uint, decimal> Cashiers = new RemoteDic<uint, decimal>() { name = "Cashiers", db = "Live" };

    }
    public class Session : RemoteDB
    {
        public RemoteMember<DateTime> sessionBegin = new RemoteMember<DateTime>() { name = "sessionBegin", db = "Session" };
        public RemoteMember<DateTime> sessionEnd = new RemoteMember<DateTime>() { name = "sessionEnd", db = "Session" };

        public RemoteDic<uint, BasicSale> Sales = new RemoteDic<uint, BasicSale>() { name = "Sales", db = "Session" };
        public RemoteDic<uint, StockIntake> StockIntakes = new RemoteDic<uint, StockIntake>() { name = "StockIntakes", db = "Session" };
    }

    public class People : RemoteDB
    {
        public RemoteDic<uint, Vendor> Vendors = new RemoteDic<uint, Vendor>() { name = "Vendors", db = "People" };
        public RemoteDic<uint, User> Users = new RemoteDic<uint, User>() { name = "Users", db = "People" };
        public RemoteDic<uint, Person> OtherPeople = new RemoteDic<uint, Person>() { name = "OtherPeople", db = "People" };
    }

    public class History : RemoteDB
    {
        public RemoteList<string> Sessions = new RemoteList<string>() { name = "Sessions", db = "History" };
        public RemoteMember<IDMachine> IdMachine = new RemoteMember<IDMachine>() { name = "IdMachine", db = "History" };
    }

    public class Settings : RemoteDB
    {
        public RemoteMember<BillSettings> billSetting = new RemoteMember<BillSettings>() { name = "billSetting", db = "Settings" };
        public RemoteMember<CommonSettings> commonSettings = new RemoteMember<CommonSettings>() { name = "commonSettings", db = "Settings" };
    }

    public class RemoteDB
    {

    }

    public class RemoteMember<T>
    {
        public string db;
        public string name;
        public virtual T Get
        {
            get
            {
                var resp = client.Request((byte)Request.Command.get, db, name, null);
                if (resp.result == (byte)Response.Result.ok)
                {
                    return resp.obj;
                }
                else
                {
                    Log($"Get {db}.{name} failed. {VisualizeObj(resp)}");
                }
                return default;

            }
        }

        public virtual void Set(T value)
        {
            var resp = client.Request((byte)Request.Command.set, db, name, new dynamic[] { value });
            if (resp.result != (byte)Response.Result.ok)
            {
                Log($"Set {db}.{name} failed. {VisualizeObj(resp)}");
            }
        }

        public virtual T GetSet
        {
            get
            {
                return Get;
            }
            set
            {
                Set(value);
            }
        }

    }

    public class RemoteDic<TKey, TVal> : RemoteMember<Dictionary<TKey, TVal>>
    {
        public TVal GetItem(TKey key)
        {

            var resp = client.Request((byte)Request.Command.get, db, name, (dynamic)key);
            if (resp.result == (byte)Response.Result.ok)
            {
                return resp.obj;
            }
            else
            {
                Log($"Get {db}.{name} failed. {VisualizeObj(resp)}");
            }
            return default;

        }
        public void Set(TKey key, TVal value)
        {
            var resp = client.Request((byte)Request.Command.set, db, name, new dynamic[] { key, value });
            if (resp.result != (byte)Response.Result.ok)
            {
                Log($"Set dic {db}.{name} failed. {VisualizeObj(resp)}");
            }
        }
        public void Add(TKey key, TVal value)
        {
            var resp = client.Request((byte)Request.Command.add, db, name, new dynamic[] { key, value });
            if (resp.result != (byte)Response.Result.ok)
            {
                Log($"Add dic {db}.{name} failed. {VisualizeObj(resp)}");
            }
        }
        public void Remove(TKey key)
        {
            var resp = client.Request((byte)Request.Command.rem, db, name, new dynamic[] { key });
            if (resp.result != (byte)Response.Result.ok)
            {
                Log($"Remove dic {db}.{name} failed. {VisualizeObj(resp)}");
            }
        }
    }
    public class RemoteList<T> : RemoteMember<T>
    {
        public void Set(int index, T value)
        {
            var resp = client.Request((byte)Request.Command.set, db, name, new dynamic[] { index, value });
            if (resp.result != (byte)Response.Result.ok)
            {
                Log($"Set List {db}.{name} failed. {VisualizeObj(resp)}");
            }
        }
        public void Add(int index, T value)
        {
            var resp = client.Request((byte)Request.Command.add, db, name, new dynamic[] { index, value });
            if (resp.result != (byte)Response.Result.ok)
            {
                Log($"Add List {db}.{name} failed. {VisualizeObj(resp)}");
            }
        }
        public void Remove(int index)
        {
            var resp = client.Request((byte)Request.Command.rem, db, name, new dynamic[] { index });
            if (resp.result != (byte)Response.Result.ok)
            {
                Log($"Remove List {db}.{name} failed. {VisualizeObj(resp)}");
            }
        }
    }
}
