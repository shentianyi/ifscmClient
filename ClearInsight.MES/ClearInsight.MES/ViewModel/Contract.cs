using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ClearInsight.MES.ViewModel
{
    public class Contract : EntityBase
    {
        public string Nr { get; set; }
        public string ArrangeStaff { get; set; }
        public string State { get; set; }
        public string Detail { get; set; }
        public string Value { get; set; }
        public Workshop Workshop { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        private static string[] status = new string[3] { "首次排单", "提单", "推单" };

        public static List<Contract> GetSource()
        {
            List<Contract> contracts = new List<Contract>();
            Random r = new Random();
            DateTime date = DateTime.Now;
            for (int i = 0; i < 30; i++)
            {
                contracts.Add(new Contract()
                {
                    ID = i,
                    Nr = "C201404" + i.ToString(),
                    ArrangeStaff = "排产员A",
                    Value = r.Next(80, 150).ToString(),
                    Time = date.AddDays(i - 7).AddHours(r.Next(4, 8)).AddMinutes(r.Next(10, 30)).ToString(),
                    State = status[i/10]
                });
            }
            return contracts;
        }
    }
    public class WorkshopContract
    {
        public Workshop Workshop { get; set; }
        public string Date { get; set; }
        public string OriValue { get; set; }
        public string MoveupValue { get; set; }
        public string MovedownValue { get; set; }
        public string ContractValue { get; set; }
        public string PredictValue { get; set; }
        public string WorkerAblityValue { get; set; }
        public string ProductAblityValue { get; set; }
        public string OEE { get; set; }
        public string TEEP { get; set; }
    }
}
