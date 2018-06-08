using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Permissions;

namespace DirectoryWatcher
{
    class Program
    {

        public static List<String> processFilesList = new List<string>();
        public static void Main()
        {
            Run();
            
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Run()
        {
            string[] args = { "", @"C:\InputFolderPath"};

            // If a directory is not specified, exit program.
            if (args.Length != 2)
            {
                // Display the proper way to call the program.
                Console.WriteLine("Usage: Watcher.exe (directory)");
                return;
            }

            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = args[1];
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            watcher.Filter = "*.xml";

            // Add event handlers.
            //watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            //watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program.
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.

            if (e.ChangeType.ToString() == "Created")
            {
                processFilesList.Add(e.FullPath);
            }

            if (processFilesList.Count!=0 && e.ChangeType.ToString() == "Deleted" && processFilesList.Exists(x => x == e.FullPath))
            {
                processFilesList.Remove(e.FullPath);
            } 

            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            Console.WriteLine(processFilesList.Count);
        }
      
    }
}
