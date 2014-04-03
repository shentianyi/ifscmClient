using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ClearInsight.MES.ViewModel
{
    public class AnalyseCollection : ObservableCollection<AnalyseMeta>
    {
        public AnalyseCollection() {
            DateTime dt = DateTime.Now;
            Random r = new Random();
            for (int i = 0; i < 5; i++) {
                this.Add(new AnalyseMeta() { Date=dt.AddYears(0-i).ToString("yyyy"),Value=r.Next(300,400).ToString()});
            }
        }
    }

    public class AnalyseMeta:EntityBase {
        public string Date { get; set; }
        public string Value { get; set; }
        public string Unit { get { return "百万"; } }

    }
}
