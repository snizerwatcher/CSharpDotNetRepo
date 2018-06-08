using System;
using ApplicationA.DirectoryWatcher;
using ApplicationA.SignalRServer;


namespace ApplicationA
{
    class Program
    {    
        static void Main(string[] args)
        {
            Server.StartServer();
        }
    }
  
}