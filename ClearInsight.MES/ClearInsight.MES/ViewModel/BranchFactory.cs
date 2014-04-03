using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClearInsight.MES.ViewModel
{
    public class BranchFactory : EntityBase
    {

        public List<Workshop> Workshops { get; set; }

        private static List<BranchFactory> source = new List<BranchFactory>() { 
         new BranchFactory(){Name="金属",ID=1},
         new BranchFactory(){Name="尼龙",ID=2}
        };

        public static List<BranchFactory> GetSource() {
            return source;
        }
    }
}
