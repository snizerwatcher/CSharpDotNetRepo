using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GenerateSampleBatchApp.Models;
using System.Xml;
using System.IO;

namespace GenerateSampleBatchApp
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length != 0)
            {
                string path = args[0];
                if (Directory.Exists(@""+path)) {

                    string folderPath = path;

                    XmlDocument doc = new XmlDocument();
                    XmlWriterSettings settings = new XmlWriterSettings();
                    List<string> dataList = new List<string>();


                    for (int i = 1; i <= 1000; i++)
                    {

                        string color = i % DateTime.Now.Second == 0 ? "red" : (i % 5 == 0 ? "green" : "blue");
                        dataList.Add((new SampleData { value = i, type = color }).ToString());
                    }

                    doc.LoadXml(String.Concat("<data>\n", String.Join("\n", dataList), "</data>"));
                    settings.Indent = true;


                    XmlWriter writer = XmlWriter.Create(folderPath + @"\" + "data-R1000.xml", settings);
                    doc.Save(writer);
                    Console.WriteLine("File Created");
                
                }
                else
                {
                    Console.WriteLine("Invalid Path");
                }

            }
            else
            {
                Console.WriteLine("Please provide folder path to save the file e.g C:\\Temp");
            }

        }
    }
}
