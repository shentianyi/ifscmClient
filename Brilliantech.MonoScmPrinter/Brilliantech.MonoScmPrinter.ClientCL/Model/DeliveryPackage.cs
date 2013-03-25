using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brilliantech.MonoScmPrinter.ClientCL.Model
{
    public class DeliveryPackage : DeliveryBase
    {
        public string cpartNr { get; set; }
        public int packAmount { get; set; }
        public int partRelId { get; set; }
        public double perPackAmount { get; set; }
        public string purchaseNo { get; set; }
        public string saleNo { get; set; }
        public string spartNr { get; set; }
        public double total { get; set; }
    }
}
