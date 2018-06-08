using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using System.Configuration;
using Shared;
using System.IO;
using System.Collections;
using System.Xml;
using System.Collections.Generic;
using ApplicationA.DirectoryWatcher;
using ApplicationA.Reader;
using System.Threading;


namespace ApplicationA.SignalRServer
{
    public class Server
    {

        public static string host;
        public static string port;
        public static string inputFolderPath;
        public static string fileExtension;
        public static string mode;
        public static List<String> processFilesList = new List<string>();
        static void SetSettings()
        {
            host = System.Configuration.ConfigurationManager.AppSettings[AppSettings.host.ToString()];
            port = System.Configuration.ConfigurationManager.AppSettings[AppSettings.port.ToString()];
            inputFolderPath = System.Configuration.ConfigurationManager.AppSettings[AppSettings.inPutFolderPath.ToString()];
            fileExtension = System.Configuration.ConfigurationManager.AppSettings[AppSettings.fileExtension.ToString()];
            mode = System.Configuration.ConfigurationManager.AppSettings[AppSettings.mode.ToString()];
            
        }

        static void StartWatcher() {
            FolderWatcher.StartFolderWatching(inputFolderPath, fileExtension);
            processFilesList = FolderWatcher.processFilesList;
        }

        public static void RemoveProcessedFile(string path)
        {
            int index = Server.processFilesList.IndexOf(path);
            processFilesList.RemoveAt(index);
        }

        public static void StartServer()
        {   
            SetSettings();

            string path = inputFolderPath;


            if (Directory.Exists(path))
            {

                StartWatcher();

                string url = String.Concat("http://", host, ":", port);
                using (WebApp.Start<Startup>(url))
                {
                    Console.WriteLine("Application A running on {0} to listen requests of Application B instances", url);
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Please provide the InputFolderPath in .config file\n"+
                                  "and restart the Server");
                Console.ReadLine();
            }




        }
    }
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
    public class Producer : Hub
    {
      
        public void fetchRecord(string type)
        {
            int value = 0;

            Console.WriteLine("Incomming Request From Application B with parameter : {0} - {1} {2}", type, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());

            if (Server.processFilesList.Count != 0)
            {
                string path = Server.processFilesList[0];

                if (!ReadXml.startRead)
                {
                    ReadXml.StartReading(path);
                    ReadXml.startRead = true;

                }


                if (type.Equals("red"))
                {
                    if (ReadXml.red.Count != 0)
                    {
                        value = ReadXml.red.Dequeue().value;
                    }
                    else
                    {
                        value = -1;
                    }
                }
                else if (type.Equals("blue"))
                {
                    if (ReadXml.blue.Count != 0)
                    {
                        value = ReadXml.blue.Dequeue().value;
                    }
                    else
                    {
                        value = -1;
                    }
                }
                else if (type.Equals("green"))
                {
                    if (ReadXml.green.Count != 0)
                    {
                        value = ReadXml.green.Dequeue().value;
                    }
                    else
                    {
                        value = -1;
                    }
                }
                else
                {
                    value = -1;
                }

                if (value>=0)
                {
                    Clients.Caller.PrintValueToConsole(value);
                    Console.WriteLine("Send Response to Application B with parameter : {0} & value : {1} - {2} {3}", type, value, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
                    Console.WriteLine("File : {0}", path);
                    Console.WriteLine("");
                }
                else
                {
                    Clients.Caller.PrintValueToConsole(value);
                   
                    Console.WriteLine("Record already consumed with parameter : {0} - {1} {2}", type, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
                    Console.WriteLine("File : {0}", path);
                    Console.WriteLine("");

                }
                

                if (ReadXml.checkFullyConsume())
                {                   
                   
                    ReadXml.startRead = false;
                    Server.RemoveProcessedFile(path);                  
                   
                }


            }
            else
            {
                Clients.Caller.PrintValueToConsole(-1);
                Console.WriteLine("Currently no file is available for processing {0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
                Console.WriteLine("");
            }

            if(Server.mode.Equals("slow")) {
                Thread.Sleep(1500);
            }
            
        }
    }
}