using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReadXmlFile
{
    class Program
    {
        public static List<SampleData> red = new List<SampleData>();
        public static List<SampleData> blue = new List<SampleData>();
        public static List<SampleData> green = new List<SampleData>();
        static void Main(string[] args)
        {

            IEnumerable<XElement> elementRecordList = XElement.Load(@"C:\InputFolderPath\data.xml").Elements("record");

            red = filterDataByType(elementRecordList, "red");
            blue = filterDataByType(elementRecordList, "blue");
            green = filterDataByType(elementRecordList, "green");

            Console.ReadLine();
        }

        static List<SampleData>  filterDataByType(IEnumerable<XElement> list, string type)
        {
            return (from x in list
                    where x.Attribute("type").Value.Equals(type)
                     select new SampleData { type = x.Attribute("type").Value,
                                             value = int.Parse(x.Attribute("value").Value) }).ToList<SampleData>();
        }
    }



    class SampleData
    {

        public int value { get; set; }

        public string type { get; set; }

        public override string ToString()
        {
            return "<record value=\"" + this.value + "\" " + "type=\"" + this.type + "\"/>";
        }
    }
}
