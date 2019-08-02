using LankaStocks.DataBases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LankaStocks.UIForms;

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

    }

    public class IntergratedServer : BaseServer
    {

    }

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
