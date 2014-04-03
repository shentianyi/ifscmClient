using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClearInsight.MES.ViewModel
{
    public class Schedule : EntityBase
    {



    }

    public class FailSchedule : Schedule
    {
        public string Date { get; set; }
        public string ContractAmount { get; set; }
        public string ProductAmount { get; set; }
        public string  Reason
        {
            get
            {
                return ScheduleFailReason.GetSource()[r.Next(0, 4)].Name;
            }
        }

        private static Random r = new Random();

    }

    public class ScheduleFailReason : EntityBase
    {
        public static List<ScheduleFailReason> GetSource()
        {
            return new List<ScheduleFailReason>()
            {
                new ScheduleFailReason(){ID=1,Name="员工缺勤"},
                new ScheduleFailReason(){ID=2,Name="库存不足"},
                new ScheduleFailReason(){ID=3,Name="产线整顿"},
                new ScheduleFailReason(){ID=4,Name="产能不足"}
            };
        }
    }
}
