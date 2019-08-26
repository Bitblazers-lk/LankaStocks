using LankaStocks.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LankaStocks.Core;

namespace LankaStocks
{
    public class ServerExecute
    {
        public BaseServer svr;

        public DBLive Live { get => svr.Live; set => svr.Live = value; }
        public DBPeople People { get => svr.People; set => svr.People = value; }
        public DBHistory History { get => svr.History; set => svr.History = value; }
        public DBSettings Settings { get => svr.Settings; set => svr.Settings = value; }




        public (bool, string) LoginCheck(string name, string pass)
        {
            foreach (var usr in People.Users.Values)
            {
                if (usr.userName == name)
                {
                    if (usr.pass == pass)
                    {

                        Log($"User login : {name}");
                        return (true, "Wellcome");
                    }
                    else
                    {
                        Log($"User wrong password : {name}");
                        return (false, "Wrong password");
                    }
                }
            }
            Log($"Wrong user name : {name}");
            return (false, "Wrong user name or password");
        }


        public Response AddNewVendor(Vendor v)
        {
            if (v.ID == 0) { History.IdMachine.PersonID++; v.ID = History.IdMachine.PersonID; }
            if (v.VendorID == 0) { History.IdMachine.VendorID++; v.VendorID = History.IdMachine.VendorID; }

            if (People.Vendors.ContainsKey(v.ID))
            {
                return Response.CreateError(Response.Result.wrongInputs, "VendorID already exists");
            }
            Log("Adding new vendor");

            return SetVendor(v);
        }

        public Response SetVendor(Vendor v)
        {
            People.Vendors[v.ID] = v;

            Log($"Set {v.ToString()} \n {Core.VisualizeObj(v)}");

            return new Response(Response.Result.ok);
        }


        public Response AddNewUser(User v)
        {
            if (v.ID == 0) { History.IdMachine.PersonID++; v.ID = History.IdMachine.PersonID; }
            if (v.UserID == 0) { History.IdMachine.UserID++; v.UserID = History.IdMachine.UserID; }

            if (People.Users.ContainsKey(v.ID))
            {
                return Response.CreateError(Response.Result.wrongInputs, "UserID already exists");
            }
            Log("Adding new user");

            return SetUser(v);
        }

        public Response SetUser(User v)
        {
            People.Users[v.ID] = v;
            Log($"Set {v.ToString()} \n {Core.VisualizeObj(v)}");
            return new Response(Response.Result.ok);
        }

        public Response AddNewPerson(Person v)
        {


            if (v.ID == 0) { History.IdMachine.PersonID++; v.ID = History.IdMachine.PersonID; }

            if (People.OtherPeople.ContainsKey(v.ID))
            {
                return Response.CreateError(Response.Result.wrongInputs, "OtherPersonID already exists");
            }

            Log("Adding new person");

            return SetPerson(v);
        }

        public Response SetPerson(Person v)
        {
            People.OtherPeople[v.ID] = v;
            Log($"Set {v.ToString()} \n {Core.VisualizeObj(v)}");
            return new Response(Response.Result.ok);
        }





        public Response AddItem(Item v)
        {
            if (v.itemID == 0) { History.IdMachine.ItemID++; v.itemID = History.IdMachine.ItemID; }

            if (Live.Items.ContainsKey(v.itemID))
            {
                return Response.CreateError(Response.Result.wrongInputs, "ItemID already exists");
            }
            Log($"Adding new {v.ToString()}");

            return SetItem(v);
        }
        public Response SetItem(Item v)
        {

            if (Live.Items.TryGetValue(v.itemID, out Item old))
            {
                foreach (var vend in v.vendors)
                {
                    People.Vendors[vend].supplyingItems.Remove(v.itemID);
                }
            }


            foreach (var vend in v.vendors)
            {
                if (People.Vendors.TryGetValue(vend, out Vendor vendor))
                {
                    vendor.supplyingItems.Add(v.itemID);
                }
            }


            Live.Items[v.itemID] = v;
            Log($"Set {v.ToString()} \n {Core.VisualizeObj(v)}");
            return new Response(Response.Result.ok);
        }

        public Response StockIntake(StockIntake si)
        {
            if (si.IntakeID == 0) { History.IdMachine.IntakeID++; si.IntakeID = History.IdMachine.IntakeID; }
            if (Live.Session.StockIntakes.ContainsKey(si.IntakeID))
            {
                return Response.CreateError(Response.Result.wrongInputs, "StockIntakeID already exists");
            }


            Live.Session.StockIntakes.Add(si.IntakeID, si);

            Log($"Taken new {si.ToString()} \n {Core.VisualizeObj(si)}");

            return new Response(Response.Result.ok);
        }


        public Dictionary<uint, string> ListItems()
        {
            Dictionary<uint, string> items = new Dictionary<uint, string>(Live.Items.Count);

            foreach (var item in Live.Items.Values)
            {
                items.Add(item.itemID, $"{item.itemID}.{item.name} - Rs. {item.outPrice} - {item.Quantity} available");
            }


            return items;
        }




        public void CLIRun(string s, ref Response resp)
        {
            string[] A = s.Split(' ');

            StringBuilder sb = new StringBuilder();

            try
            {
                try
                {


                    switch (A[0])
                    {
                        case "list":
                            switch (A[1])
                            {
                                case "users":
                                    sb.AppendLine(VisualizeObj(People.Users));
                                    break;

                                case "vendors":
                                    sb.AppendLine(VisualizeObj(People.Vendors));
                                    break;

                                case "otherpeople":
                                    sb.AppendLine(VisualizeObj(People.OtherPeople));
                                    break;

                                case "items":
                                    sb.AppendLine(VisualizeObj(Live.Items));
                                    break;
                                default:
                                    break;
                            }
                            break;

                        case "fix":
                            switch (A[1])
                            {
                                case "vendors":
                                    foreach (var vend in People.Vendors.Values)
                                    {
                                        vend.supplyingItems = new List<uint>();
                                    }
                                    break;

                                case "items":
                                    foreach (var item in Live.Items.Values)
                                    {
                                        if (item.vendors == null) { item.vendors = new List<uint>(); sb.AppendLine($"Set empty list for null vendors of item {item.name}"); }
                                        foreach (var v in item.vendors)
                                        {
                                            if (!People.Vendors.ContainsKey(v))
                                            {
                                                item.vendors.Remove(v);

                                                sb.AppendLine($"Fixed incorrect vendor for item. Set {item.name}.vendor to {People.Vendors.First().Value.name}({item.vendors})");
                                            }
                                        }
                                        if (item.vendors.Count == 0)
                                        {

                                            item.vendors.Add(People.Vendors.First().Key);
                                            sb.AppendLine($"Vendors for this Item is empty. Add {People.Vendors.First().Value.name}({item.vendors[0]}) {item.name}.vendor");
                                        }

                                    }

                                    break;

                                default:
                                    break;
                            }

                            break;

                        case "exit":
                            Core.Shutdown();
                            break;

                        case "save":
                            if (A.Length == 1)
                            {
                                Live.ForceSave();
                                People.ForceSave();
                                History.ForceSave();
                                Settings.ForceSave();
                            }
                            else
                            {
                                switch (A[1])
                                {
                                    case "all":
                                        Live.ForceSave();
                                        People.ForceSave();
                                        History.ForceSave();
                                        Settings.ForceSave();
                                        break;

                                    case "live":
                                        Live.ForceSave();
                                        break;
                                    case "people":
                                        People.ForceSave();
                                        break;
                                    case "history":
                                        History.ForceSave();
                                        break;
                                    case "settings":
                                        Settings.ForceSave();
                                        break;

                                    default:
                                        break;
                                }
                            }
                            break;


                        case "revert":
                            if (A.Length == 1)
                            {
                                Live = (DBLive)Live.DiscardChanges();
                                People = (DBPeople)People.DiscardChanges();
                                History = (DBHistory)History.DiscardChanges();
                                Settings = (DBSettings)Settings.DiscardChanges();
                            }
                            else
                            {
                                switch (A[1])
                                {
                                    case "all":
                                        Live = (DBLive)Live.DiscardChanges();
                                        People = (DBPeople)People.DiscardChanges();
                                        History = (DBHistory)History.DiscardChanges();
                                        Settings = (DBSettings)Settings.DiscardChanges();
                                        break;

                                    case "live":
                                        Live = (DBLive)Live.DiscardChanges();
                                        break;
                                    case "people":
                                        People = (DBPeople)People.DiscardChanges();
                                        break;
                                    case "history":
                                        History = (DBHistory)History.DiscardChanges();
                                        break;
                                    case "settings":
                                        Settings = (DBSettings)Settings.DiscardChanges();
                                        break;

                                    default:
                                        break;
                                }
                            }
                            break;



                        default:
                            break;
                    }

                }
                catch (System.IndexOutOfRangeException ex)
                {

                    LogErr(ex, "Cannot Parse command.Maybe this command needs more arguments");
                    throw;
                }
                catch (Exception ex)
                {

                    LogErr(ex, "Cannot Parse and Excecute command");
                    throw;
                }

            }
            catch (Exception ex)
            {
                resp.msg = ErrorStamp(ex, "Cannot Parse and Excecute command");
                resp.result = (byte)Response.Result.failed;
                resp.obj = ex;
                return;
            }

            resp.result = (byte)Response.Result.ok;
            resp.msg = sb.ToString();
        }
    }
}
