using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

        
        
         string text = File.ReadLines(Path.Combine(@Environment.CurrentDirectory,"testing_file.txt")).Reverse().Take(10).Where(x => x.ToString() != null && x.ToString()!=" " && x.ToString()!= Environment.NewLine &&  Char.IsLetter(x.ToString(),1) != true).First();

            
        
        
        
        }
    }
}



