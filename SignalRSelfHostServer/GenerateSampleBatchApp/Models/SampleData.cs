using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GenerateSampleBatchApp.Models
{
  
    class SampleData
    {
     
        public int value { get; set;}
       
        public string type { get; set; }      
      
        public override string ToString()
        {
            return "<record value=\""+this.value+"\" "+"type=\""+this.type+"\"/>";
        }
    }
}
