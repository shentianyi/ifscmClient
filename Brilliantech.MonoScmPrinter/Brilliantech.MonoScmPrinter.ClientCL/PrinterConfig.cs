using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.MonoScmPrinter.BaseCL.Utilities.ConfigUtil;
using System.IO;
using TECIT.TFORMer;
using Brilliantech.MonoScmPrinter.ClientCL.Model;

namespace Brilliantech.MonoScmPrinter.ClientCL
{
    public class PrinterConfig
    {
        private static ConfigUtil printerConfig;
        private static int _copy;
        private static string _templatePath;
        private static string _printerName;
        private static PrinterType _printerType;

        static PrinterConfig()
        {
            printerConfig = new ConfigUtil("Printer", "Config/printerConfig.ini");
            _copy = int.Parse(printerConfig.Get("Copy"));
            _templatePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, printerConfig.Get("Template")); 
            //_templatePath = "";
            _printerName = printerConfig.Get("PrinterName");
            _printerType = (PrinterType)int.Parse(printerConfig.Get("PrinterType"));
        }
        public static int Copy
        {
            get { return PrinterConfig._copy; }
            set
            {
                PrinterConfig._copy = value;
                printerConfig.Set("Copy", value);
            }
        }
        public static string TemplatePath
        {
            get { return PrinterConfig._templatePath; }
            set
            {
                PrinterConfig._templatePath = value;
                printerConfig.Set("Template", value);
            }
        }

        public static string PrinterName
        {
            get { return PrinterConfig._printerName; }
            set
            {
                PrinterConfig._printerName = value;
                printerConfig.Set("PrinterName", value);
            }
        }


        public static PrinterType PrinterType
        {
            get { return PrinterConfig._printerType; }
            set
            {
                PrinterConfig._printerType = value;
                printerConfig.Set("PrinterType", (int)value);
            }
        }

        public static void SaveSettings() {
            printerConfig.Save();
        }

        public static ReturnMsg<string> CopyTemplate(string sourceFileName)
        {
            ReturnMsg<string> msg = new ReturnMsg<string>() { result = false };
            if (File.Exists(sourceFileName))
            {
                string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, PrinterConfig.TemplatePath);
                if (!Directory.Exists(templatePath))
                {
                    Directory.CreateDirectory(templatePath);
                }
                string destFileName = Path.Combine(templatePath, Path.GetFileName(sourceFileName));
                File.Copy(sourceFileName, destFileName, true);
                msg.result = true;
                msg.@object = "成功导入模版";
            }
            else {
                msg.@object = "源文件不存在,请核实";
            }
            return msg;
        }
    }
}
