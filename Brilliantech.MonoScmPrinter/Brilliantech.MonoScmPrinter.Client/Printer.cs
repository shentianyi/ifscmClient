using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.MonoScmPrinter.ClientCL.Model;
using Brilliantech.MonoScmPrinter.ClientCL.IRestApis;
using Brilliantech.MonoScmPrinter.ClientCL.RestApis;
using Brilliantech.ReportGenConnector;
using Brilliantech.MonoScmPrinter.ClientCL;
using System.IO;
using Brilliantech.MonoScmPrinter.ClientCL.Enums; 

namespace Brilliantech.MonoScmPrinter.Client
{
    public class Printer
    {
        public static ReturnMsg<string> Print(PrintData data)
        {
            string template = System.IO.Path.Combine(SettingConfig.TemplatePath, data.template);
            if (!File.Exists(template))
            {
                Downloader.DownLoadTemplate(new string[] { data.template });
            }
            IGenPrinter printer = new GenPrinter();
            ReportGenConfig printerConfig = new ReportGenConfig()
            {
                NumberOfCopies = SettingConfig.Copy,
                Printer = SettingConfig.PrinterName,
                PrinterType = SettingConfig.PrinterType,
                Template = template
            };
            return printer.Print(data.dataset, printerConfig);
        }
    }
}
