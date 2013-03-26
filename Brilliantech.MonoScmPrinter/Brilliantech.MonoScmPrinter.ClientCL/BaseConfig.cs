using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.MonoScmPrinter.BaseCL.Utilities.ConfigUtil;

namespace Brilliantech.MonoScmPrinter.ClientCL
{
    public class BaseConfig
    {
        private static string _templateBucket;
        private static string _apiBaseUrl;
        private static string _apiLoginAction;
        private static string _dnPrintQueueListAction;
        private static string _dnRemoveFromPrintQueueAction;
        //private static string _dnPackageListAction;
        private static string _dnItemListAction;
        private static string _dnItemPrintDataAction;
        private static string _updatePrinterTemplateAction;
        private static string _dnClientPackTemplateAction;
        private static string _dnArriveAction;

        static BaseConfig()
        {
            ConfigUtil baseConfig = new ConfigUtil("BaseConfig", "Config/baseConfig.ini");
            _templateBucket = baseConfig.Get("TemplateBucket");
            _apiBaseUrl = baseConfig.Get("ResetApiUrl");

            _apiLoginAction = _apiBaseUrl + baseConfig.Get("ApiLoginAction");
            _dnPrintQueueListAction = _apiBaseUrl + baseConfig.Get("DnPrintQueueListAction");
            _dnRemoveFromPrintQueueAction = _apiBaseUrl + baseConfig.Get("DnFromRemovePrintQueueAction");
            //_dnPackageListAction = _apiBaseUrl + baseConfig.Get("DnPackageListAction");
            _dnItemListAction = _apiBaseUrl + baseConfig.Get("DnItemListAction");
            _dnItemPrintDataAction = _apiBaseUrl + baseConfig.Get("DnItemPrintDataAction");
            _updatePrinterTemplateAction = _apiBaseUrl + baseConfig.Get("UpdatePrinterTemplateAction");
            _dnClientPackTemplateAction = _apiBaseUrl + baseConfig.Get("DnClientPackTemplateAction");
            _dnArriveAction = _apiBaseUrl + baseConfig.Get("DnArriveAction");
        }

        public static string TemplateBucket
        {
            get { return BaseConfig._templateBucket; }
        }

        public static string ApiLoginUrl
        {
            get { return BaseConfig._apiLoginAction; }
        }

        public static string DnPrintQueueListUrl
        {
            get { return BaseConfig._dnPrintQueueListAction; }
        }

        public static string DnRemoveFromPrintQueueAction
        {
            get { return BaseConfig._dnRemoveFromPrintQueueAction; }
        }
        //public static string DnPackageListAction
        //{
        //    get { return BaseConfig._dnPackageListAction; }
        //}

        public static string DnItemListAction
        {
            get { return BaseConfig._dnItemListAction; }
        }

        public static string DnItemPrintDataAction
        {
            get { return BaseConfig._dnItemPrintDataAction; }
        }

        public static string UpdatePrinterTemplateAction
        {
            get { return BaseConfig._updatePrinterTemplateAction; }
        }

        public static string DnClientPackTemplateAction
        {
            get { return BaseConfig._dnClientPackTemplateAction; }
        }

        public static string DnArriveAction
        {
            get { return BaseConfig._dnArriveAction; }
        }


        public static void InitConfig() { }

    }
}
