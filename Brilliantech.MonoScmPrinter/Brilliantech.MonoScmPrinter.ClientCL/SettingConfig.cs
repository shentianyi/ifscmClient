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
    public class SettingConfig
    {
        private static ConfigUtil printerConfig;
        private static ConfigUtil proxyConfig;
        private static int _copy;
        private static string _templatePath;
        private static string _printerName;
        private static PrinterType _printerType;
        private static NetProxyType _netProxyType = NetProxyType.NoProxy;

 
        static SettingConfig()
        {
            printerConfig = new ConfigUtil("Printer", "Config/settingConfig.ini");
            _copy = int.Parse(printerConfig.Get("Copy"));
            _templatePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, printerConfig.Get("Template")); 
            _printerName = printerConfig.Get("PrinterName");
            _printerType = (PrinterType)int.Parse(printerConfig.Get("PrinterType"));
            proxyConfig = new ConfigUtil("ProxyConfig", "Config/settingConfig.ini");
            _netProxyType = NetProxy.GetNetProxyType(int.Parse(proxyConfig.Get("NetProxy")));
        }
        public static int Copy
        {
            get { return SettingConfig._copy; }
            set
            {
                SettingConfig._copy = value;
                printerConfig.Set("Copy", value);
            }
        }
        public static string TemplatePath
        {
            get { return SettingConfig._templatePath; }
            set
            {
                SettingConfig._templatePath = value;
                printerConfig.Set("Template", value);
            }
        }

        public static string PrinterName
        {
            get { return SettingConfig._printerName; }
            set
            {
                SettingConfig._printerName = value;
                printerConfig.Set("PrinterName", value);
            }
        }
        public static PrinterType PrinterType
        {
            get { return SettingConfig._printerType; }
            set
            {
                SettingConfig._printerType = value;
                printerConfig.Set("PrinterType", (int)value);
            }
        }

        public static NetProxyType NetProxyType
        {
            get { return SettingConfig._netProxyType; }
            set
            {
                SettingConfig._netProxyType = value;
                proxyConfig.Set("NetProxy", (int)value);
            }
        }

        public static void SavePrinterSettings() {
            printerConfig.Save();
        }


        public static void SaveProxySettings()
        {
            proxyConfig.Save();
        }

        public static ReturnMsg<string> CopyTemplate(string sourceFileName)
        {
            ReturnMsg<string> msg = new ReturnMsg<string>() { result = false };
            if (File.Exists(sourceFileName))
            {
                string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SettingConfig.TemplatePath);
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
