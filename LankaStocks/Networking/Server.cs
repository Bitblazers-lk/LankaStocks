using LankaStocks.DataBases;
using LankaStocks.UIForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks
{
    public abstract class BaseServer
    {
        public static DBLive Live;
        public static DBPeople People;
        public static DBHistory History;
        public static DBSettings Settings;



        public void Initialize()
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


        public (bool, string) LoginCheck(string name, string pass)
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
                        return (true, "Wellcome");
                    }
                    else
                    {
                        return (false, "Wrong password");
                    }
                }
            }
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
                    resp.obj = LoginCheck(req.para[0], req.para[1]);
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

        public enum Result : byte { unknown, ok, failed, notfound, warning, retry }
    }

}
