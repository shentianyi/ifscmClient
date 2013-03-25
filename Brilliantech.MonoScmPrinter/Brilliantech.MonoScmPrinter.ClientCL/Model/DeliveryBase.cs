using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brilliantech.MonoScmPrinter.ClientCL.Model
{
    public class DeliveryBase
    {
        public int? id { get; set; }
        public string key { get; set; }
        public string parentKey { get; set; }
        public DateTime? created_at { get; set; }
        public List<object> items { get; set; }
    }
}
