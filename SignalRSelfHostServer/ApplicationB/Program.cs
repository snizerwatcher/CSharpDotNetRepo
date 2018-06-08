using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Shared;
using System.Threading;

namespace ApplicationB
{
    class Program
    {
        private static string host;
        private static string port;
        private static string mode;
        private static bool flag=false;

        static void SetSettings()
        {
            host = System.Configuration.ConfigurationManager.AppSettings[AppSettings.host.ToString()];
            port = System.Configuration.ConfigurationManager.AppSettings[AppSettings.port.ToString()];
            mode = System.Configuration.ConfigurationManager.AppSettings[AppSettings.mode.ToString()];
            
        }

        static void Main(string[] args)
        {
            SetSettings();

            string[] type = Enum.GetNames(typeof(RecordType));


            if (args.Length != 0 && type.Contains(args[0].ToLower()))
            {
               Program.EstablishedConnection(args[0].ToLower());              
               
            }
            else
            {
                Console.WriteLine("Please provide record type\n"+
                                  "Valid record types are {0}, {1} & {2}",RecordType.blue.ToString(),
                                  RecordType.green.ToString(),RecordType.red.ToString());
            }

            Console.ReadLine();
           
        }

        static void PrintToConsole(int data)
        {
            if (data!=-1) {
                 Console.WriteLine("-{0}", data);                
            }
            else
            {
                flag = true;
            }
        }


        public async static void EstablishedConnection(string type)
        {
            try
            {
                string url = String.Concat("http://", host, ":", port, "/", "signalr");
                var hubConnection = new HubConnection(url);

                IHubProxy client = hubConnection.CreateHubProxy("Producer");
                Action<int> printAction = PrintToConsole;    
            
                client.On<int>("PrintValueToConsole", printAction);

                await hubConnection.Start();

                while (!flag)
                {
                    await client.Invoke("fetchRecord", type);
                    if (mode.Equals("slow"))
                    {
                        Thread.Sleep(1500);
                    } 
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Appplication A is not running");
            }
        }

        
    }
}
