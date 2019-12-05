using LankaStocks.DataBases;
using LankaStocks.UIForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public BinaryFormatter BF = new BinaryFormatter();

        public Stream Respond(Stream reqStrm)
        {
            var req = (Request)BF.Deserialize(reqStrm);

            var resp = Respond(req);

            MemoryStream respMS = new MemoryStream();
            BF.Serialize(respMS, resp);
            respMS.Seek(0, SeekOrigin.Begin);
            return respMS;
        }
        public void RespondTo(Stream reqStrm, Stream respStrm)
        {
            var req = (Request)BF.Deserialize(reqStrm);

            var resp = Respond(req);

            BF.Serialize(respStrm, resp);
        }

        public byte[] Respond(byte[] reqBytes)
        {

            MemoryStream reqMS = new MemoryStream(reqBytes);
            var req = (Request)BF.Deserialize(reqMS);

            var resp = Respond(req);

            MemoryStream respMS = new MemoryStream();
            BF.Serialize(respMS, resp);
            return respMS.ToArray();

        }

        public Response Respond(Request req)
        {
            Response resp = new Response() { msg = "" };

            switch ((Request.Command)req.command)
            {
                case Request.Command.none:

                    break;
                case Request.Command.peer:
                    resp = RespondPeerReq(req.db, req.para[0], req.expr);
                    break;
                case Request.Command.exec:

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
            bool peer = true;
            resp.result = (byte)Response.Result.ok;
            try
            {
                switch (req.expr)
                {
                    case "login":
                        resp.obj = exe.LoginCheck(req.para[0], req.para[1]); peer = false;
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
                    case "DeleteUser":
                        resp = exe.DeleteUser(req.para[0]);
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
                    case "DeleteItem":
                        resp = exe.DeleteItem(req.para[0]);
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
                        resp.obj = exe.ListItems(); peer = false;
                        break;
                    case "CLIRun":
                        exe.CLIRun(req.para[0], ref resp);
                        break;
                    default:
                        break;
                }
                peer = peer && (resp != null && (resp.result < (byte)Response.Result.retry));

                if (IsHost && peer) BroadcastToPeers(req);
            }
            catch (Exception ex)
            {
                resp = new Response(Response.Result.failed, $"Failed to Execute the request : {Core.ErrorStamp(ex, "Cannot process the execute request")}.");
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


        public Dictionary<string, PeerStatus> Peers = new Dictionary<string, PeerStatus>();
        public ScrollableArray<Request> Requests = new ScrollableArray<Request>(32);

        public uint LastPeerIndex = 0;

        public uint CurrentPeerPoint = 0U;
        public uint MinPeerPoint = 0U;

        private bool PeeringBusy = false;

        public virtual Response RespondPeerReq(string PeerID, uint ReqPeerPoint, string expr)
        {
            PeerStatus peer;
            switch (expr)
            {
                case "add me":
                    ExtendPeerID:

                    LastPeerIndex++;

                    PeerID = $"{PeerID}{LastPeerIndex}";

                    if (Peers.ContainsKey(PeerID))
                    {
                        goto ExtendPeerID;
                    }

                    break;

                case "reload":
                    if (Peers.TryGetValue(PeerID, out peer))
                    {
                        peer.LastPoint = CurrentPeerPoint;
                        return new Response(Response.Result.ok, null, "reload", (Live, People, Settings));
                    }
                    break;
            }


            while (PeeringBusy)
            {
                System.Threading.Thread.Sleep(10);
            }

            PeeringBusy = true;

            lock (Peers)
            {

                if (!Peers.TryGetValue(PeerID, out peer))
                {
                    //New peer

                    peer = new PeerStatus() { ID = PeerID, LastActivity = DateTime.Now, LastPoint = CurrentPeerPoint };
                    Peers.Add(PeerID, peer);
                    Log($"Added new peer {PeerID}");
                    PeeringBusy = false;
                    return new Response(Response.Result.notfound, null, "new peer", (Live, People, History, Settings, peer));
                }


                peer.LastActivity = DateTime.Now;
                peer.LastPoint = ReqPeerPoint;

                int count = (int)(CurrentPeerPoint - peer.LastPoint);

                PeeringBusy = false;
                if (count == 0) return new Response(Response.Result.ok, null, null, new PeerPackage() { Point = CurrentPeerPoint });


                PeerPackage pack = new PeerPackage() { Point = CurrentPeerPoint, requests = new Request[count] };

                Requests.CopyTo(pack.requests, (int)(peer.LastPoint - MinPeerPoint), count);


                Log($"Sent {count} requests to peer {PeerID} {{ {peer.LastPoint} to {CurrentPeerPoint} }} {VisualizeObj(pack.requests)}");

                peer.LastPoint = CurrentPeerPoint;

                PeeringBusy = false;
                return new Response(Response.Result.ok, null, null, pack);
            }
        }

        public void BroadcastToPeers(Request req)
        {
            if (Peers.Count == 0)
                return;

            if (IsDebug) Log($"Broadcast added {((Request.Command)req.command).ToString()} {req.db}.{req.expr}  - {string.Join(" ", req.para)}");
            lock (Peers)
            {
                Requests.AddToBack(req);
                CurrentPeerPoint++;
            }
        }

        public void CleanupPeers()
        {
            lock (Peers)
            {
                while (PeeringBusy)
                {
                    System.Threading.Thread.Sleep(10);
                }

                PeeringBusy = true;

                var timeThreash_hold = DateTime.Now.AddMinutes(-10);
                List<string> timoutPeers = new List<string>();
                bool hasTimoutPeers = false;

                foreach (PeerStatus peer in from PeerStatus peer in Peers.Values
                                            where peer.LastActivity < timeThreash_hold
                                            select peer)
                {
                    timoutPeers.Add(peer.ID);
                    hasTimoutPeers = true;
                }

                foreach (var id in timoutPeers)
                {
                    Peers.Remove(id);
                }

                if (IsDebug && hasTimoutPeers) Log($"Cleaned {timoutPeers.Count} out of time peers");

                uint LowestPoint = CurrentPeerPoint;

                foreach (PeerStatus peer in Peers.Values)
                {
                    if (peer.LastPoint < LowestPoint)
                        LowestPoint = peer.LastPoint;
                }

                if (LowestPoint == MinPeerPoint)
                {
                    PeeringBusy = false;
                    return;
                }

                var cleaned = LowestPoint - MinPeerPoint;
                Requests.RemoveFromBegining((int)(LowestPoint - MinPeerPoint));
                MinPeerPoint = LowestPoint;

                PeeringBusy = false;

                if (IsDebug) Log($"Cleaned {cleaned} fully broadcasted requests. Currently at '{CurrentPeerPoint}' peer point. {CurrentPeerPoint - LowestPoint} points yet to send. {MinPeerPoint} MinPeerPoint");
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
                bool isFirstRun = !File.Exists(BasePath + DB.StampPath);
                if (isFirstRun)
                {
                    if (!Directory.Exists(BasePath + DB.DBPath)) Directory.CreateDirectory(BasePath + DB.DBPath);
                    if (!Directory.Exists(BasePath + DB.HistoryPath)) Directory.CreateDirectory(BasePath + DB.HistoryPath);

                    byte[] stamp = new byte[256];
                    random.NextBytes(stamp);
                    File.WriteAllBytes(BasePath + DB.StampPath, stamp);

                    Log($"Created new Data Base on {DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day} \n");
                    MessageBox.Show("Welcome To LankaStocks!\nNote :\n\tUsername - preLogin\n\tPassword - preLogin LankaS", "LanakaStocks > Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadDatabasesFromDisk(isFirstRun);

                exe = new ServerExecute { svr = this };

                Statics.ReCalculate();

                if (Live.Session.Name != DateTime.Now.ToString("yyyyMMdd"))
                {

                    Log($"Saving last day session {Live.Session.Name}", ConsoleColor.Cyan);
                    Live.Session.sessionEnd = DateTime.Now;
                    History.SaveSession(Live.Session);

                    Log("Starting a fresh Session just for you. Have a good day!", ConsoleColor.Cyan);
                    Live.Session.CreateNewDatabase();
                    foreach (var item in Live.Cashiers)
                    {
                        Live.Session.BeginingCashiers.Add(item.Key, item.Value);
                    }
                    foreach (var item in Live.Items)
                    {
                        Live.Session.BeginingItems.Add(item.Key, item.Value);
                    }
                }

                PeerTimer = new System.Timers.Timer(10000);
                PeerTimer.Elapsed += PeerTimer_Elapsed;
                PeerTimer.Start();



                System.Threading.Thread DBSaveThread = new System.Threading.Thread(new System.Threading.ThreadStart(ThrDBSave));
                DBSaveThread.Start();
            }

        }

        public System.Timers.Timer PeerTimer;

        private void PeerTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CleanupPeers();
        }

        private void LoadDatabasesFromDisk(bool isFirstRun)
        {
            Live = (DBLive)new DBLive() { DBName = "DBLive", FileName = BasePath + DB.DBPath + "DBLive.db" }.LoadBinary(isFirstRun);
            People = (DBPeople)new DBPeople() { DBName = "DBPeople", FileName = BasePath + DB.DBPath + "DBPeople.db" }.LoadBinary(isFirstRun);
            History = (DBHistory)new DBHistory() { DBName = "DBHistory", FileName = BasePath + DB.DBPath + "DBHistory.db" }.LoadBinary(isFirstRun);
            Settings = (DBSettings)new DBSettings() { DBName = "DBSettings", FileName = BasePath + DB.DBPath + "DBSettings.db" }.LoadBinary(isFirstRun);
        }



        private void ThrDBSave()
        {
            Begin:

            for (int n = 0; n < 30; n++)
            {
                Live.SaveBinary();
                People.SaveBinary();
                History.SaveBinary();
                Settings.SaveBinary();

                System.Threading.Thread.Sleep(10000);
            }

            Live.ForceSave();
            People.ForceSave();
            History.ForceSave();
            Settings.ForceSave();

            goto Begin;
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
                ID = Core.user?.ID.ToString("00"),
                LastActivity = time
            };

            exe = new ServerExecute { svr = this };

            Response resp = client.Peer(status.ID, 0U, "add me");

            if (resp.result == (byte)Response.Result.notfound)
            {
                (DBLive Live, DBPeople People, DBHistory History, DBSettings Settings, PeerStatus peer) tup = resp.obj;
                Live = tup.Live; People = tup.People; History = tup.History; Settings = tup.Settings;

                status.ID = tup.peer.ID; status.LastActivity = tup.peer.LastActivity; status.LastPoint = tup.peer.LastPoint;

                Log($"Using peer ID {status.ID}");
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

            try
            {
                Peer();
            }
            catch (Exception ex)
            {
                LogErr(ex, "Peering Error on Peer database");
            }

            PeererBusy = false;
        }



        public void Peer()
        {
            Response resp = client.Peer(status.ID, status.LastPoint);

            if (resp.result == (byte)Response.Result.ok)
            {
                var pack = (PeerPackage)resp.obj;

                if (status.LastPoint == pack.Point) return;
                if (pack.requests == null)
                {
                    Log("!!! Peer server recieved null request array");
                    return;
                }

                if (IsDebug) Log($"Peered {pack.requests.Length} requests");

                foreach (var req in pack.requests)
                {
                    Respond(req);
                    if (IsDebug) Log($"Peer {status.ID} : Processed {((Request.Command)req.command).ToString()} {req.db}.{req.expr}  - {string.Join(" ", req.para)} ~ {VisualizeObj(req.para[0])}");
                }

                status.LastPoint = pack.Point;

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

    [Serializable]
    public class PeerStatus
    {
        public string ID;
        public uint LastPoint;
        public DateTime LastActivity;
    }

    [Serializable]
    public class PeerPackage
    {
        public uint Point;
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

        public enum Result : byte { unknown, ok, warning, retry, failed, notfound, wrongInputs }

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