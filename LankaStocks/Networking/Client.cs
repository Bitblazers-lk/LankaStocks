using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks.Networking
{

    public abstract class BaseClient
    {
        public abstract void Initialize();
        public abstract (bool, string) LoginCheck(string name, string pass);


    }
    public class IntergratedClient : BaseClient
    {
        public IntergratedServer svr;

        public override void Initialize()
        {
            svr = new IntergratedServer();
            svr.Initialize();
        }

        public override (bool, string) LoginCheck(string name, string pass) => svr.LoginCheck(name, pass);
    }

}
