using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brilliantech.MonoScmPrinter.ClientCL.Model
{
    public class DeliveryNote : DeliveryBase
    {
        public int staff_id { get; set; }
        public int organisation_id { get; set; }
        public int rece_org_id { get; set; }
        public int? wayState { get; set; }
        public string destination { get; set; }
        public DateTime? sendDate { get; set; }       
    }
}
