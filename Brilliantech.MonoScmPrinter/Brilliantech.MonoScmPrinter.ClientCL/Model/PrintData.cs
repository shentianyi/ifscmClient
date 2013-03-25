using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.ReportGenConnector;

namespace Brilliantech.MonoScmPrinter.ClientCL.Model
{
   public  class PrintData
    {
       public bool result { get; set; }
       public string content { get; set; }
       public string template { get; set; }
       public RecordSet dataset { get; set; }
    }
}
