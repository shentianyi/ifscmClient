using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.MonoScmPrinter.ClientCL.IRestApis;
using Brilliantech.ReportGenConnector;
using Brilliantech.MonoScmPrinter.ClientCL.Model;
using Brilliantech.MonoScmPrinter.ClientCL.Enums;

namespace Brilliantech.MonoScmPrinter.ClientCL.RestApis
{
    public class GenPrinter : IGenPrinter
    {
        public ReturnMsg<string> Print(RecordSet data, ReportGenConfig printerConfig)
        {
            ReturnMsg<string> msg = new ReturnMsg<string>() { result = false };
            try
            {
                IReportGen gen = new TecITGener();
                gen.Print(data, printerConfig);
                msg.result = true;
                msg.content = "打印成功";
                msg.level = MsgLevel.Successful;
            }
            catch (Exception e) {
                msg.content = e.Message;
                msg.level = MsgLevel.Mistake;
            }
            return msg;
        }
    }
}
