using LankaStocks.DataBases;
using LankaStocks.UIForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LankaStocks.Core;

namespace LankaStocks
{
    public abstract class BaseServer
    {
        public DBLive Live;
        public DBPeople People;
        public DBHistory History;
        public DBSettings Settings;

        public ServerExecute exe;

        public void Initialize()
        {
            {
                Log("Initializing Server");
                bool isFirstRun = !File.Exists(DB.StampPath);
                if (isFirstRun)
                {
                    byte[] stamp = new byte[256];
                    random.NextBytes(stamp);
                    File.WriteAllBytes(DB.StampPath, stamp);

                    File.AppendAllText(DB.LogPath, $"Created new Data Base on {DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day} \n");
                }

                Live = (DBLive)new DBLive() { DBName = "DBLive", FileName = DB.DBPath + "DBLive.db" }.LoadBinary(isFirstRun);
                People = (DBPeople)new DBPeople() { DBName = "DBPeople", FileName = DB.DBPath + "DBPeople.db" }.LoadBinary(isFirstRun);
                History = (DBHistory)new DBHistory() { DBName = "DBHistory", FileName = DB.DBPath + "DBHistory.db" }.LoadBinary(isFirstRun);
                Settings = (DBSettings)new DBSettings() { DBName = "DBSettings", FileName = DB.DBPath + "DBSettings.db" }.LoadBinary(isFirstRun);

                exe = new ServerExecute { svr = this };

                Statics.ReCalculate();
            }

        }

        public void Shutdown()
        {
            foreach (var usr in People.Users.Values)
            {
                if (usr.userName == name)
                {
                    if (usr.pass == pass)
                    {
                        //Forms.dashboard.Hide();
                        Forms.dashboard = new Dashboard();
                        Forms.dashboard.Show();
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


        public Response Respond(Request req)
        {
            Response resp = new Response() { msg = "" };

            switch ((Request.Command)req.command)
            {
                case Request.Command.none:

                    break;
                case Request.Command.exec:
                    Execute(req, ref resp);
                    break;
                case Request.Command.get:
                case Request.Command.set:
                case Request.Command.add:
                case Request.Command.rem:
                    RespondGetSetAddRem(req, ref resp);
                    break;
                default:
                    resp.result = (byte)Response.Result.unknown;
                    break;
            }
            return resp;
        }

        public void Execute(Request req, ref Response resp)
        {
            resp.result = (byte)Response.Result.ok;
            switch (req.expr)
            {
                case "login":
                    resp.obj = exe.LoginCheck(req.para[0], req.para[1]);
                    break;
                case "AddNewVendor":
                    resp.obj = exe.AddNewVendor(req.para[0]);
                    break;
                case "AddNewUser":
                    resp.obj = exe.AddNewUser(req.para[0]);
                    break;
                case "AddNewPerson":
                    resp.obj = exe.AddNewPerson(req.para[0]);
                    break;
                case "SetVendor":
                    resp.obj = exe.SetVendor(req.para[0]);
                    break;
                case "SetUser":
                    resp.obj = exe.SetUser(req.para[0]);
                    break;
                case "SetPerson":
                    resp.obj = exe.SetPerson(req.para[0]);
                    break;
                case "AddItem":
                    resp.obj = exe.AddItem(req.para[0]);
                    break;
                case "SetItem":
                    resp.obj = exe.SetItem(req.para[0]);
                    break;
                case "StockIntake":
                    resp.obj = exe.StockIntake(req.para[0]);
                    break;



                case "ListItems":
                    resp.obj = exe.ListItems();
                    break;

                default:
                    break;
            }
        }

        public void RespondGetSetAddRem(Request req, ref Response resp)
        {
            switch (req.db)
            {
                case "Live":
                    Live.Respond(req, ref resp);
                    break;
                case "People":
                    People.Respond(req, ref resp);
                    break;
                case "History":
                    History.Respond(req, ref resp);
                    break;
                case "Settings":
                    Settings.Respond(req, ref resp);
                    break;
                case "Session":
                    Live.Session.Respond(req, ref resp);
                    break;
                default:
                    resp.result = (byte)Response.Result.unknown;
                    break;
            }

        }




    }

    public class IntergratedServer : BaseServer
    {

    }


    [Serializable]
    public class Transmit
    {

    }

    [Serializable]
    public class Request : Transmit
    {
        public byte command;
        public string db;
        public string expr;
        public dynamic[] para;

        public enum Command : byte { none, exec, get, set, add, rem }
    }

    [Serializable]
    public class Response : Transmit
    {
        public byte result;
        public string msg;
        public string expr;
        public dynamic obj;

        public enum Result : byte { unknown, ok, failed, notfound, warning, retry, wrongInputs }

        public Response() { }

        public Response(Result result, string msg = null, string expr = null, dynamic obj = null)
        {
            this.result = (byte)result;
            this.msg = msg;
            this.expr = expr;
            this.obj = obj;
        }

        public static Response CreateError(Result res, string message, dynamic obj = null)
        {
            return new Response() { expr = null, msg = message, result = (byte)res, obj = obj };
        }
    }

}
