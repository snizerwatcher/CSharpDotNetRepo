using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Permissions;

namespace ApplicationA.DirectoryWatcher
{
    class FolderWatcher
    {
        public static List<String> processFilesList = new List<string>();        
       
        public static void StartFolderWatching(string watchFolderPath, string fileExtension)
        {
            Start(watchFolderPath,fileExtension);
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Start(string watchFolderPath, string fileExtension)
        {          

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = watchFolderPath;

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.Filter =  String.Concat("*.",fileExtension);

           

            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
     
            watcher.EnableRaisingEvents = true;           
        }


        private static void OnChanged(object source, FileSystemEventArgs e)
        {

            if (e.ChangeType.ToString() == "Created")
            {
                processFilesList.Add(e.FullPath);
            }

            if (processFilesList.Count != 0 && e.ChangeType.ToString() == "Deleted" && processFilesList.Exists(x => x.Equals(e.FullPath)))
            {
                processFilesList.Remove(e.FullPath);               
            }

        }
    }
}
