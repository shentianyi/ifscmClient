using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ClearInsight.MES.ViewModel
{
    public class WorkshopContractCollection : ObservableCollection<WorkshopContract>
    {
        public WorkshopContractCollection()
        {
            DateTime StartDate = DateTime.Now.AddDays(-7), EndDate = DateTime.Now.AddDays(4);
            Random r = new Random();
            for (DateTime i = StartDate; i < EndDate; i = i.AddDays(1))
            {
                this.Add(new WorkshopContract()
                {
                    Date = i.ToString("yyyy/MM/dd"),
                    OriValue = r.Next(80, 150).ToString(),
                    MoveupValue = r.Next(0, 20).ToString(),
                    MovedownValue = r.Next(0, 30).ToString(),
                    ContractValue = r.Next(90, 160).ToString(),
                    PredictValue = r.Next(95, 150).ToString()
                });
            }
        }
    }
}
