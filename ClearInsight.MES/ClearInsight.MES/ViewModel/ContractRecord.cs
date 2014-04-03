using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Controls.Timelines;

namespace ClearInsight.MES.ViewModel
{
    public class ContractRecord
    {
        public DateTime Time { get; set; }
        public int Duration { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        //public static List<ContractRecord> GetResource()
        //{
        //    List<ContractRecord> collection = new List<ContractRecord>();
        //    DateTimeSeries 
        //    Random r=new Random ();
        //    DateTime date = DateTime.Now.AddDays(r.Next(-7,7));
        //    for (int i = 1; i < 10; i++)
        //    {
        //        ContractRecord dataEntry = new ContractRecord()
        //        {
        //            Time = DateTime.Now.AddDays(r.Next(-7,7)),
        //            Title = "Data Title " + i,
        //            Details = "Data Description " + i
        //        };
        //        collection.Add(dataEntry);


        //    }
        //    return collection;
        //}
    }
}
