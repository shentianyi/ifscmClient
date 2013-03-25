using Brilliantech.ReportGenConnector;
using MonoScmPrinterService.IHelper;
using System;
using System.Runtime.InteropServices;
using Brilliantech.MonoScmPrinter.BaseCL.Utilities.ConfigUtil;
using TECIT.TFORMer;

namespace MonoScmPrinterService.Helper
{
    public class GenPrinterBase : IGenPrinter
    {
        protected static int copy;
        protected static string printerBase;
        protected static PrinterType printerType;
        protected static string templateBasePath;

        protected ReportGenConfig taskConfig;
        protected string folderPath;
        protected PrintTask task = null;
        protected string filePath = null;

        static GenPrinterBase()
        {
            ConfigUtil config = new ConfigUtil("DNPdfGenConfig", "Config/dnPdfConfig.ini");
            copy = int.Parse(config.Get("Copy"));
            printerBase = config.Get("PrinterBase");
            templateBasePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, config.Get("TemplatePath"));
            printerType = (PrinterType)int.Parse(config.Get("PrinterType"));
        }

        public GenPrinterBase(string folderPath, string template)
        {
            this.folderPath = folderPath;
            this.taskConfig = new ReportGenConfig()
            {
                NumberOfCopies = copy,
                Printer = printerBase,
                Template = templateBasePath + "/" + template,
                PrinterType=printerType
            };
        }

        public void Print(RecordSet data, string fileName)
        {
            IReportGen gen = new TecITGener();
            this.filePath = this.folderPath+"/"+fileName;
            this.taskConfig.Printer += filePath;
            gen.Print(data, this.taskConfig);
        }

        public string GetFilePath()
        {
            return this.filePath;
        }
    }
}
