using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClearInsight.MES.ViewModel
{
    public class Workshop : EntityBase
    {
        public BranchFactory BranchFactory { get; set; }

        private static List<Workshop> source = new List<Workshop>() { 
         new Workshop(){Name="金属一",ID=1,BranchFactory=BranchFactory.GetSource()[0]},
         new Workshop(){Name="金属二",ID=2,BranchFactory=BranchFactory.GetSource()[0]},
         new Workshop(){Name="金属三",ID=3,BranchFactory=BranchFactory.GetSource()[0]},
         new Workshop(){Name="尼龙一",ID=4,BranchFactory=BranchFactory.GetSource()[1]},
         new Workshop(){Name="尼龙二",ID=5,BranchFactory=BranchFactory.GetSource()[1]},
         new Workshop(){Name="尼龙三",ID=6,BranchFactory=BranchFactory.GetSource()[1]}
        };

        public static List<Workshop> GetSource() { 
         return source;
        }
        public static List<Workshop> GetSource(int branchFactoryID)
        {
            if (branchFactoryID == 1)
            {
                return source.GetRange(0, 3);
            }
            return source.GetRange(3, 3);
        }

       
    }


}
