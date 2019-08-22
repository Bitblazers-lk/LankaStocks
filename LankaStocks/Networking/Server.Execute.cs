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

        public DBLive Live => svr.Live;
        public DBPeople People => svr.People;
        public DBHistory History => svr.History;
        public DBSettings Settings => svr.Settings;




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
                if (v.vendor != 0U)
                {
                    People.Vendors[v.vendor].supplyingItems.Remove(v.itemID);
                }
            }


            if (v.vendor != 0U)
            {
                if (People.Vendors.TryGetValue(v.vendor, out Vendor vend))
                {
                    vend.supplyingItems.Add(v.itemID);
                }
            }


            Live.Items[v.itemID] = v;
            Log($"Set {v.ToString()} \n {Core.VisualizeObj(v)}");
            return new Response(Response.Result.ok);
        }
    }
}
