using LankaStocks.DataBases;
using LankaStocks.UIForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LankaStocks.Core;

namespace LankaStocks.Networking
{
    public abstract class BaseServer
    {
        public DBLive Live;
        public DBPeople People;
        public DBHistory History;
        public DBSettings Settings;

        public ServerExecute exe;

        public bool IsHost = true;
        public abstract void Initialize();




        public abstract void Shutdown();



        public Response Respond(Request req)
        {
            Response resp = new Response() { msg = "" };

            switch ((Request.Command)req.command)
            {
                case Request.Command.none:

                    break;
                case Request.Command.peer:
                    resp = RespondPeerReq(req.db, req.expr);
                    break;
                case Request.Command.exec:
                    if (IsHost) BroadcastToPeers(req);
                    Execute(req, ref resp);
                    break;
                case Request.Command.get:
                    RespondGetSetAddRem(req, ref resp);
                    break;

                case Request.Command.set:
                case Request.Command.add:
                case Request.Command.rem:
                    if (IsHost) BroadcastToPeers(req);
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
                    resp = exe.AddNewVendor(req.para[0]);
                    break;
                case "AddNewUser":
                    resp = exe.AddNewUser(req.para[0]);
                    break;
                case "AddNewPerson":
                    resp = exe.AddNewPerson(req.para[0]);
                    break;
                case "SetVendor":
                    resp = exe.SetVendor(req.para[0]);
                    break;
                case "SetUser":
                    resp = exe.SetUser(req.para[0]);
                    break;
                case "SetPerson":
                    resp = exe.SetPerson(req.para[0]);
                    break;
                case "AddItem":
                    resp = exe.AddItem(req.para[0]);
                    break;
                case "SetItem":
                    resp = exe.SetItem(req.para[0]);
                    break;
                case "StockIntake":
                    resp = exe.StockIntake(req.para[0]);
                    break;
                case "Sale":
                    resp = exe.Sale(req.para[0]);
                    break;
                case "RefundItem":
                    resp = exe.RefundItem(req.para[0]);
                    break;



                case "ListItems":
                    resp.obj = exe.ListItems();
                    break;


                case "CLIRun":
                    exe.CLIRun(req.para[0], ref resp);
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






        #region PeerStuff


        // ________ Peer stuff _________________ //

        public Queue<Request> requests = new Queue<Request>();
        public Dictionary<string, PeerStatus> peers = new Dictionary<string, PeerStatus>();
        public uint CurrentUpdate = 0U;
        private uint CurrentQueueRootUpdate = 0U;

        public virtual Response RespondPeerReq(string PeerID, string expr)
        {
            switch (expr)
            {
                case "add me":
                    ExtendPeerID:
                    if (peers.ContainsKey(PeerID))
                    {
                        PeerID += "X";
                        goto ExtendPeerID;
                    }
                    break;
            }



            if (!peers.TryGetValue(PeerID, out PeerStatus peer))
            {
                //New peer

                peer = new PeerStatus() { ID = PeerID, LastActivity = DateTime.Now, LastUpdate = CurrentUpdate };
                peers.Add(PeerID, peer);
                Log($"Added new peer {PeerID}");
                return new Response(Response.Result.notfound, null, "new peer", (Live, People, History, Settings, peer));
            }




            peer.LastActivity = DateTime.Now;

            int count = (int)(CurrentUpdate - peer.LastUpdate);

            if (count == 0) return new Response(Response.Result.ok, null, null, new PeerPackage() { Update = CurrentUpdate });

            PeerPackage pack = new PeerPackage() { Update = CurrentUpdate, requests = new Request[count] };

            requests.CopyTo(pack.requests, (int)(peer.LastUpdate - CurrentQueueRootUpdate));

            peer.LastUpdate = CurrentUpdate;

            Log($"Sent {count} requests to peer {PeerID}");
            return new Response(Response.Result.ok, null, null, pack);
        }

        public void BroadcastToPeers(Request req)
        {
            if (peers.Count == 0)
                return;

            Log("Broadcast added");
            requests.Enqueue(req);
            CurrentUpdate++;
        }


        public void CleanupPeers()
        {
            var timeThreash_hold = DateTime.Now.AddMinutes(-10);
            List<string> timoutPeers = new List<string>();

            foreach (PeerStatus peer in from PeerStatus peer in peers.Values
                                        where peer.LastActivity < timeThreash_hold
                                        select peer)
            {
                timoutPeers.Add(peer.ID);
            }

            foreach (var id in timoutPeers)
            {
                peers.Remove(id);
            }

        }


        #endregion



    }





    public class HostServer : BaseServer
    {
        public override void Initialize()
        {
            {
                Log("Initializing Server");
                bool isFirstRun = !File.Exists(DB.StampPath);
                if (isFirstRun)
                {
                    byte[] stamp = new byte[256];
                    random.NextBytes(stamp);
                    File.WriteAllBytes(DB.StampPath, stamp);

                    Log($"Created new Data Base on {DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day} \n");
                }

                LoadDatabasesFromDisk(isFirstRun);

                exe = new ServerExecute { svr = this };

                Statics.ReCalculate();

                PeerTimer = new System.Timers.Timer(10000);
                PeerTimer.Elapsed += PeerTimer_Elapsed;
                PeerTimer.Start();
            }

        }



        public System.Timers.Timer PeerTimer;

        private void PeerTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CleanupPeers();
        }

        private void LoadDatabasesFromDisk(bool isFirstRun)
        {
            Live = (DBLive)new DBLive() { DBName = "DBLive", FileName = DB.DBPath + "DBLive.db" }.LoadBinary(isFirstRun);
            People = (DBPeople)new DBPeople() { DBName = "DBPeople", FileName = DB.DBPath + "DBPeople.db" }.LoadBinary(isFirstRun);
            History = (DBHistory)new DBHistory() { DBName = "DBHistory", FileName = DB.DBPath + "DBHistory.db" }.LoadBinary(isFirstRun);
            Settings = (DBSettings)new DBSettings() { DBName = "DBSettings", FileName = DB.DBPath + "DBSettings.db" }.LoadBinary(isFirstRun);
        }





        public override void Shutdown()
        {
            Log("Host Sever shutingdown");
            Live.ForceSave();
            People.ForceSave();
            History.ForceSave();
            Settings.ForceSave();
        }
    }



    public class PeerServer : BaseServer
    {
        public BaseClient client;
        public PeerStatus status;

        public override void Initialize()
        {
            IsHost = false;


            AquirePeerID:
            DateTime time = DateTime.Now;
            status = new PeerStatus()
            {
                ID = $"{Core.user?.ID}-{time.Hour}:{time.Minute}.{time.Second}.{time.Millisecond}",
                LastActivity = time
            };

            Log($"Using peer ID {status.ID}");

            Response resp = client.Peer(status.ID, "add me");

            if (resp.result == (byte)Response.Result.notfound)
            {
                (DBLive Live, DBPeople People, DBHistory History, DBSettings Settings, PeerStatus peer) tup = resp.obj;
                Live = tup.Live; People = tup.People; History = tup.History; Settings = tup.Settings; status = tup.peer;
                Log("Downloaded Peer Database");
            }
            else if (resp.result == (byte)Response.Result.ok)
            {
                //Somene is using that PeerID
                Log($"Somene is using that PeerID. Changing...");
                goto AquirePeerID;
            }
            else
            {
                Log($"Fatel error. Cannot Download Peer Databases. {resp.msg} \t {resp.expr}");
            }



            timer = new System.Timers.Timer(3000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

        }

        private bool PeererBusy = false;
        public System.Timers.Timer timer;
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (PeererBusy) return;
            PeererBusy = true;
            Peer();
            PeererBusy = false;
        }



        public void Peer()
        {
            Response resp = client.Peer(status.ID);
            if (resp.result == (byte)Response.Result.ok)
            {
                var reqs = (Request[])resp.obj;
                foreach (var req in reqs)
                {
                    Respond(req);
                }
                Log($"Peered and Processed {reqs.Length} requests");
            }
            else if (resp.result == (byte)Response.Result.notfound)
            {
                (DBLive Live, DBPeople People, DBHistory History, DBSettings Settings, PeerStatus peer) tup = resp.obj;
                Live = tup.Live; People = tup.People; History = tup.History; Settings = tup.Settings; status = tup.peer;
                Log("Downloaded Peer Database again. Looks like we were inactive for a while. Check your network connection");
            }
            else
            {
                Log($"Fatel error. Cannot Peer. {resp.msg} \t {resp.expr}");
            }
        }



        public override void Shutdown()
        {
            Log("Peer Sever shutingdown");
        }
    }

    public class PeerStatus
    {
        public string ID;
        public uint LastUpdate = 0;
        public DateTime LastActivity;
    }

    public class PeerPackage
    {
        public uint Update;
        public Request[] requests;
    }

    public class IntergratedServer : HostServer
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

        public enum Command : byte { none, exec, get, set, add, rem, peer }
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