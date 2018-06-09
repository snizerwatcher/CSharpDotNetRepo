using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_Async_await_
{
    class scatterGather
    {

        public async Task<List<string>> start(List<string> data)
        {

            List<string> dataSplitA = new List<string>();
            List<string> dataSplitB = new List<string>();
            List<string> dataSplitC = new List<string>();

            dataSplitA = await scatter(data.GetRange(0, 60000));
            dataSplitB = await scatter(data.GetRange(60000, 60000));
            dataSplitC = await scatter(data.GetRange(120000, 60000));

            return dataSplitA.Concat(dataSplitB).Concat(dataSplitC).ToList<string>();  //gather
        }


        public async Task<List<string>> start2(List<string> data)
        {

          
             Task<List<string>> dataSplitA =  scatter(data.GetRange(0, 60000));
             Task<List<string>> dataSplitB =  scatter(data.GetRange(60000, 60000));
             Task<List<string>> dataSplitC =  scatter(data.GetRange(120000, 60000));

             await Task.WhenAll(dataSplitA, dataSplitB, dataSplitC);

             List<string> dataSplitAA = await dataSplitA;
             List<string> dataSplitBB = await dataSplitB;
             List<string> dataSplitCC = await dataSplitC;


            return  dataSplitAA.Concat(dataSplitBB).Concat(dataSplitCC).ToList<string>();  //gather
        }


        public async Task<List<string>> scatter(List<string> dataa)  //scatter
        {
            List<string> result = new List<string>();
                      

            for (int i = 0; i < dataa.Count; i++)
            {
                result.Add(dataa.ElementAt(i));
            }

            return result;
        }
    }
}
