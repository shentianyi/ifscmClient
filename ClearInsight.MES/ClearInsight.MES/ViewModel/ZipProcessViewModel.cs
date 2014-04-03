using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ClearInsight.MES.ViewModel
{
   public enum ZipProcessDetailType
    {
        Number,
        Devise
    }
    public class ZipProcessDetail
    {
        public string OrderNr { get; set; }
        public string DeviseNr { get; set; }
        public string DeviseName { get; set; }
        public float Value { get; set; }
        public ZipProcessDetailType Type { get; set; }

        public static List<ZipProcessDetail> GetResource(string name)
        {
            if (name == "成品")
            {
                return null;
            }
            if (name == "拉头库存")
            {
                return new List<ZipProcessDetail>() { new ZipProcessDetail() { Value = 1000, Type = ZipProcessDetailType.Number } };
            }
            List<ZipProcessDetail> details = new List<ZipProcessDetail>();
            Random r = new Random();
            int count = r.Next(3, 7);
            for (int i = 1; i < count; i++)
            {
                details.Add(new ZipProcessDetail()
                {
                    OrderNr = "ORDER20148202" + r.Next(10, 100).ToString(),
                    DeviseName = name + "设备" + r.Next(100, 200).ToString(),
                    Value = r.Next(10, 50)
                });
            }
            return details;
        }
    }
    public class ZipProcess
    {
        public ZipProcess() { this.ZipProcesses = new ObservableCollection<ZipProcess>(); }
        public ZipProcess(string name)
        {
            this.Name = name;
            this.ZipProcesses = new ObservableCollection<ZipProcess>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public ObservableCollection<ZipProcess> ZipProcesses { get; set; }
    } 

    public class ZipProcessViewModel
    {
        public ObservableCollection<ZipProcess> ZipProcesses { get; set; }

        public ZipProcessViewModel()
        {
            ZipProcess LT = new ZipProcess() { Name = "拉头(库存)" };
            ZipProcess ZS = new ZipProcess() { Name = "注塑" };
            ZipProcess ZLP = new ZipProcess() { Name = "装拉片" };
            ZLP.ZipProcesses.Add(LT);
            ZLP.ZipProcesses.Add(ZS);

            ZipProcess RS = new ZipProcess() { Name = "染色" };
            ZipProcess TP = new ZipProcess() { Name = "烫平" };
            TP.ZipProcesses.Add(RS);

            ZipProcess PM = new ZipProcess() { Name = "排咪" };
            PM.ZipProcesses.Add(ZLP);
            PM.ZipProcesses.Add(TP);

            ZipProcess QD = new ZipProcess() { Name = "切断" };
            QD.ZipProcesses.Add(PM);

             ZipProcess BZGC = new ZipProcess() { Name = "包装过秤" };
            BZGC.ZipProcesses.Add(QD);

            ZipProcess CP = new ZipProcess() { Name = "成品" };
             CP.ZipProcesses.Add(BZGC);


            this.ZipProcesses = new ObservableCollection<ZipProcess>();
            this.ZipProcesses.Add(CP);
        }
    }
}
