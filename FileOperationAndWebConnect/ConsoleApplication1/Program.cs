using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        public static void createFile(string path,string fileName,string fileExtension = ".txt")
        {

           

            string drive_path = Path.Combine(path,fileName+fileExtension);

            using (FileStream fileStream = File.Create(drive_path))
            {
                string myValue = "Love 4 All Hatred for None";
                
                byte[] data = Encoding.UTF8.GetBytes(myValue);
                fileStream.Write(data, 0, data.Length);
            }


        }

        public static void createTextFile(string path, string fileName, string fileExtension = ".txt")
        {
            string drive_path = Path.Combine(path, fileName + fileExtension);

            using (StreamWriter fileStream = File.CreateText(drive_path))
            {
                string myValue = "Love 4 All Hatred for None";
                fileStream.Write(myValue);
                
            }
        }


        public static string readTextFile(string path, string fileName, string fileExtension = ".txt")
        {
            string drive_path = Path.Combine(path, fileName + fileExtension);
            string text;
            using(FileStream fileStream = File.OpenRead(drive_path) )
            {

                byte[] data = new byte[fileStream.Length];

                for (int i=0; i < fileStream.Length;i++ )
                {
                    data[i] = (byte)fileStream.ReadByte();
                }

                text = Encoding.UTF8.GetString(data);     
            }

            return text;
        }

        public static string readTextFile1(string path, string fileName, string fileExtension = ".txt")
        {
            string drive_path = Path.Combine(path, fileName + fileExtension);
            string text;
            
            using (StreamReader fileStream = File.OpenText(drive_path))
            {
                text = fileStream.ReadToEnd();
                        
            }

            return text;
        }

        public static void print(string display)
        {
            Console.WriteLine(display);
            Console.ReadLine();
        }


        public static string communication_ovr_internet(string uri = "http://www.microsoft.com") 
        {

            WebRequest webRequest = WebRequest.Create(uri);
            WebResponse webResponse = webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string txt = reader.ReadToEnd();

           

            webResponse.Close();

            return txt;
        
        }

        static void Main(string[] args)
        {
            string path = @"G:\CWD\Cert_Prep\ConsoleApplication1\Files";

            //createFile(path,"nabeel_txt_2_byte");
            //createTextFile(path, "nabeel_txtfile");
            //print(readTextFile(path, "nabeel_txt_2_byte"));
            //print(readTextFile1(path, "nabeel_txt_2_byte"));
            //print(communication_ovr_internet());
        }
    }
}
