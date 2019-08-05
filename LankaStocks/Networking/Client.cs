using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LankaStocks.Core;

namespace LankaStocks.Networking
{

    public abstract class BaseClient
    {
        public abstract void Initialize();
        public abstract Response Request(Request req);
        public Response Request(byte command, string db, string expr, dynamic[] para) => Request(new LankaStocks.Request() { command = command, db = db, expr = expr, para = para });
        public Response Excecute(string expr, dynamic[] para) => Request(new LankaStocks.Request() { command = (byte)LankaStocks.Request.Command.exec, expr = expr, para = para });





        public (bool, string) LoginCheck(string name, string pass)
        {
            return Excecute("login", new string[] { name, pass }).obj;
        }


    }
    public class IntergratedClient : BaseClient
    {
        public IntergratedServer svr;

        public override void Initialize()
        {
            Log("Initializing Client");
            svr = new IntergratedServer();
            svr.Initialize();
        }

        public override Response Request(Request req) => svr.Respond(req);


    }

}
