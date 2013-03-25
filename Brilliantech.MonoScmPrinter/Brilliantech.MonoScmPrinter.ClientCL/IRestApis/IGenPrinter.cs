using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.ReportGenConnector;
using Brilliantech.MonoScmPrinter.ClientCL.Model;

namespace Brilliantech.MonoScmPrinter.ClientCL.IRestApis
{
    public interface IGenPrinter
    {
        ReturnMsg<string> Print(RecordSet data, ReportGenConfig printerConfig);
    }
}
