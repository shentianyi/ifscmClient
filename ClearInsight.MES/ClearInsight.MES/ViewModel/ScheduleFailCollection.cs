using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ClearInsight.MES.ViewModel
{
    public class ScheduleFailCollection : ObservableCollection<FailSchedule>
    {

        private static Random r = new Random();
     

        public ScheduleFailCollection()
        {
            DateTime StartDate = DateTime.Now.AddDays(-10), EndDate = DateTime.Now.AddDays(2);
            Random r = new Random();
            for (DateTime i = StartDate; i < EndDate; i = i.AddDays(1))
            {
                this.Add(new FailSchedule()
                {
                    Date = i.ToString("yyyy/MM/dd"),
                    ContractAmount = r.Next(10, 20).ToString(),
                    ProductAmount = r.Next(10, 20).ToString()
                });
            }
        }
    }
}
