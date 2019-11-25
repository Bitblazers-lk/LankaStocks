using LankaStocks.DataBases;
using LankaStocks.Networking;
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

        public DBLive Live { get { svr.Live.LastUpdate++; return svr.Live; } set { svr.Live.LastUpdate++; svr.Live = value; } }
        public DBPeople People { get { svr.People.LastUpdate++; return svr.People; } set { svr.People.LastUpdate++; svr.People = value; } }
        public DBHistory History { get { svr.History.LastUpdate++; return svr.History; } set { svr.History.LastUpdate++; svr.History = value; } }
        public DBSettings Settings { get { svr.Settings.LastUpdate++; return svr.Settings; } set { svr.Settings.LastUpdate++; svr.Settings = value; } }

        public (bool, string, User) LoginCheck(string name, string pass)
        {
            foreach (var usr in People.Users.Values)
            {
                if (usr.userName == name)
                {
                    if (usr.pass == pass)
                    {

                        Log($"User login : {name}");

                        return (true, "Wellcome", usr);
                    }
                    else
                    {
                        Log($"User wrong password : {name}");
                        return (false, "Wrong password", null);
                    }
                }
            }
            Log($"Wrong user name : {name}");
            return (false, "Wrong user name or password", null);
        }

        public Response AddNewVendor(Vendor v)
        {
            if (v.ID == 0) { Live.IdMachine.PersonID++; v.ID = Live.IdMachine.PersonID; }
            if (v.VendorID == 0) { Live.IdMachine.VendorID++; v.VendorID = Live.IdMachine.VendorID; }

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
            if (v.ID == 0) { Live.IdMachine.PersonID++; v.ID = Live.IdMachine.PersonID; }
            if (v.ID == 0) { Live.IdMachine.UserID++; v.ID = Live.IdMachine.UserID; }

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

        public Response DeleteUser(uint v)
        {
            People.Users.Remove(v);
            Log($"Delete {v.ToString()} Done!");
            return new Response(Response.Result.ok);
        }

        public Response AddNewPerson(Person v)
        {
            if (v.ID == 0) { Live.IdMachine.PersonID++; v.ID = Live.IdMachine.PersonID; }

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

        public Response Sale(BasicSale sale)
        {



            //Check Errors

            List<(BusinessItem, Item)> Items = new List<(BusinessItem, Item)>(sale.items.Count);

            foreach (var i in sale.items)
            {


                if (!Live.Items.TryGetValue(i.itemID, out Item root))
                {
                    return new Response(Response.Result.notfound, $"Item {i.itemID} not found");
                }

                if (root.Quantity < i.Quantity)
                {
                    return new Response(Response.Result.wrongInputs, $"We only have {root.Quantity} units of {root.name}. You Can't issue {i.Quantity}", null, root);
                }

                i.Value = root.outPrice;
                Items.Add((i, root));

            }

            if (sale.total == 0)
            {
                sale.CalculateTotal();
            }
            //Apply changes to DBs

            if (People.Users.TryGetValue(sale.UserID, out User user))
            {
                user.summary.date = DateTime.Now;
                user.summary.total += sale.total;
            }
            else
            {
                return new Response(Response.Result.failed, $"UserID {sale.UserID} not found.");
            }


            if (sale is SpecialSale special)
            {
                user.summary.Liability += special.transaction.Liability;
            }




            if (svr.IsHost && sale.SaleID == 0)
            {
                Live.IdMachine.SaleID++;
                sale.SaleID = Live.IdMachine.SaleID;
                sale.date = DateTime.Now;
            }
            else
            {
                Live.IdMachine.SaleID = Math.Max(Live.IdMachine.SaleID, sale.SaleID);
            }


            foreach ((BusinessItem itm, Item root) in Items)
            {
                root.Quantity -= itm.Quantity;
            }



            Live.Session.Sales.Add(sale.SaleID, sale);

            return new Response(Response.Result.ok, null, null, sale);
        }

        public Response RefundItem(BasicSale sale)
        {
            //Refund is an inverted Sale
            if (sale.total > 0)
            {
                sale.total *= -1;
            }


            foreach (var i in sale.items)
            {
                if (i.Value > 0)
                {
                    i.Value *= -1;
                }
            }

            return Sale(sale);

        }

        public Response AddItem(Item v)
        {
            if (v.itemID == 0) { Live.IdMachine.ItemID++; v.itemID = Live.IdMachine.ItemID; }

            if (Live.Items.ContainsKey(v.itemID))
            {
                return Response.CreateError(Response.Result.wrongInputs, "ItemID already exists");
            }
            Log($"Adding new {v.ToString()}");

            return SetItem(v);
        }

        public Response SetItem(Item v)
        {

            if (Live.Items.TryGetValue(v.itemID, out Item oldItem))
            {
                foreach (var vend in People.Vendors.Values)
                {
                    vend.supplyingItems.Remove(v.itemID);
                }

                v.Quantity = oldItem.Quantity;

            }


            if (People.Vendors.TryGetValue(v.vendor, out Vendor vendor))
            {
                vendor.supplyingItems.Add(v.itemID);
            }


            Live.Items[v.itemID] = v;
            Log($"Set {v.ToString()} \n {Core.VisualizeObj(v)}");
            return new Response(Response.Result.ok);
        }

        public Response DeleteItem(Item v)
        {
            if (Live.Items.ContainsKey(v.itemID))
            {
                try
                {
                    People.Vendors[v.vendor].supplyingItems.Remove(v.itemID);
                }
                catch { }
            }

            Live.Items.Remove(v.itemID);
            Log($"Delete {v.ToString()} Done! \n {Core.VisualizeObj(v)}");
            return new Response(Response.Result.ok);
        }

        public Response StockIntake(StockIntake si)
        {
            if (si.IntakeID == 0) { Live.IdMachine.IntakeID++; si.IntakeID = Live.IdMachine.IntakeID; }
            if (Live.Session.StockIntakes.ContainsKey(si.IntakeID))
            {
                return Response.CreateError(Response.Result.wrongInputs, "StockIntakeID already exists");
            }


            if (!Live.Items.TryGetValue(si.item.itemID, out Item root))
            {
                return new Response(Response.Result.notfound, $"Item {si.item.itemID} not found");
            }

            root.Quantity += si.item.Quantity;

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
                                    resp.msg = $"{A[1]} is not valid";
                                    resp.result = (byte)Response.Result.wrongInputs;
                                    return;
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

                                        if (!People.Vendors.ContainsKey(item.vendor))
                                        {
                                            item.vendor = 0;

                                            sb.AppendLine($"Fixed incorrect vendor for item. Set {item.name}.vendor to {item.vendor}");
                                        }

                                    }

                                    break;


                                case "users":
                                    foreach (var usr in People.Users.Values)
                                    {
                                        usr.summary = new Transaction() { User = usr.ID, ID = 1, SecondParty = usr.ID, type = Transaction.Types.Summary };
                                    }
                                    break;

                                default:
                                    resp.msg = $"{A[1]} is not valid";
                                    resp.result = (byte)Response.Result.wrongInputs;
                                    return;
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
                                        resp.msg = $"{A[1]} is not valid";
                                        resp.result = (byte)Response.Result.wrongInputs;
                                        return;
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
                                        resp.msg = $"{A[1]} is not valid";
                                        resp.result = (byte)Response.Result.wrongInputs;
                                        return;
                                }
                            }
                            break;



                        default:
                            resp.msg = $"{A[0]} is not a valid command";
                            resp.result = (byte)Response.Result.wrongInputs;
                            return;
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
