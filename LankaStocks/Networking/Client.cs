using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static LankaStocks.Core;


namespace LankaStocks.Networking
{

    public abstract class BaseClient
    {


        public PeerServer ps;

        public abstract void Initialize();
        public abstract void Shutdown();
        public abstract Response Request(Request req);
        public Response Request(byte command, string db, string expr, params dynamic[] para) => Request(new Networking.Request() { command = command, db = db, expr = expr, para = para });
        public Response Excecute(string expr, params dynamic[] para) => Request(new Networking.Request() { command = (byte)Networking.Request.Command.exec, expr = expr, para = para });



        public (bool, string, User) LoginCheck(string name, string pass) => Excecute("login", name, pass).obj;

        public Response AddNewVendor(Vendor v) => Excecute("AddNewVendor", v);
        public Response AddNewUser(User v) => Excecute("AddNewUser", v);
        public Response AddNewPerson(Person v) => Excecute("AddNewPerson", v);
        public Response EditVendor(Vendor v) => Excecute("EditVendor", v);
        public Response EditUser(User v) => Excecute("EditUser", v);
        public Response EditPerson(Person v) => Excecute("EditPerson", v);
        public Response SetVendor(Vendor v) => Excecute("SetVendor", v);
        public Response SetUser(User v) => Excecute("SetUser", v);
        public Response SetPerson(Vendor v) => Excecute("SetPerson", v);
        public Response AddItem(Item v) => Excecute("AddItem", v);
        public Response EditItem(Item v) => Excecute("EditItem", v);
        public Response SetItem(Item v) => Excecute("SetItem", v);
        public Response StockIntake(StockIntake v) => Excecute("StockIntake", v);
        public Response ListItems() => Excecute("ListItems");

        public Response Sale(BasicSale sale) => Excecute("Sale", sale);
        public Response RefundItem(BasicSale sale) => Excecute("RefundItem", sale);


        public Response CLIRun(string s) => Excecute("CLIRun", s);
        public Response Peer(string peerID, uint PeerPoint, string expr = null) => Request((byte)Networking.Request.Command.peer, peerID, expr, PeerPoint);



    }





    public class IntergratedClient : BaseClient
    {
        public IntergratedServer svr;

        public BinaryFormatter BF = new BinaryFormatter();

        public override void Initialize()
        {
            Log("Initializing Client");
            svr = new IntergratedServer();
            Core.Svr = svr;
            svr.Initialize();

            ps = new PeerServer() { client = this };
            ps.Initialize();

            
        }

        public override Response Request(Request req)
        {
            MemoryStream reqMS = new MemoryStream();
            BF.Serialize(reqMS, req);
            reqMS.Seek(0, SeekOrigin.Begin);

            var respStrm = svr.Respond(reqMS);

            return (Response)BF.Deserialize(respStrm);

        }

        public Response RequestWithBytes(Request req)
        {
            MemoryStream reqMS = new MemoryStream();
            BF.Serialize(reqMS, req);

            var buff = svr.Respond(reqMS.ToArray());

            MemoryStream respMS = new MemoryStream(buff);
            return (Response)BF.Deserialize(respMS);

        }

        public override void Shutdown()
        {
            Log("Client Shutingdown");
            svr.Shutdown();
        }
    }
}
