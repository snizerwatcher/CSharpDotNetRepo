using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApplicationA.Reader
{
    class ReadXml
    {
        public static Queue<SampleData> red = new Queue<SampleData>();
        public static Queue<SampleData> blue = new Queue<SampleData>();
        public static Queue<SampleData> green = new Queue<SampleData>();
        public static Boolean startRead = false;
        public static void StartReading(string path)
        {

            IEnumerable<XElement> elementRecordList = XElement.Load(path).Elements("record");

            red = filterDataByType(elementRecordList, "red");
            blue = filterDataByType(elementRecordList, "blue");
            green = filterDataByType(elementRecordList, "green");

            
        }

        public static bool checkFullyConsume() {
            return red.Count == 0 && blue.Count == 0 && green.Count == 0 ? true:false;
        }

        static Queue<SampleData> filterDataByType(IEnumerable<XElement> list, string type)
        {
            return new Queue<SampleData>( (from x in list
                                            where x.Attribute("type").Value.Equals(type)
                                            select new SampleData
                                            {
                                                type = x.Attribute("type").Value,
                                                value = int.Parse(x.Attribute("value").Value)
                                            }).ToList<SampleData>());
        }
    }


    public class SampleData
    {
        public int value { get; set; }

        public string type { get; set; }

        public override string ToString()
        {
            return "<record value=\"" + this.value + "\" " + "type=\"" + this.type + "\"/>";
        }
    }
}
