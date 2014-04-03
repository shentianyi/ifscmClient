using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClearInsight.MES.ViewModel
{
    public class HumanResouce
    {
        public string Date { get; set; }
        public string WorkType { get; set; }
        public string WorkTypeRate { get; set; }
        public int Value { get; set; }


        public static List<HumanResouce> GetPieSumData()
        {
            return new List<HumanResouce>() {
           new HumanResouce(){Value=3000,WorkType="入职大于1个月",WorkTypeRate="30%"},
            new HumanResouce(){Value=2800,WorkType="入职大于2个月",WorkTypeRate="23%"},
             new HumanResouce(){Value=2500,WorkType="入职大于7个月",WorkTypeRate="20%"},
              new HumanResouce(){Value=1000,WorkType="入职大于1年",WorkTypeRate="10%"},
               new HumanResouce(){Value=100,WorkType="元老",WorkTypeRate="1%"}

           };
        }
    }
}
