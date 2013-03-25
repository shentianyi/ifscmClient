using Brilliantech.MonoScmPrinter.BaseCL.Utilities.ConfigUtil;

namespace MonoScmPrinterService.Helper
{
    public class ConfigReader
    {
        private static string _dnPdfOutPutPath;
        private static string _dnBucketName;

        static ConfigReader()
        {
            ConfigUtil baseConfig = new ConfigUtil("BaseConfig", "Config/baseConfig.ini");
            ConfigReader._dnPdfOutPutPath = baseConfig.Get("DnPdfOutPath");
            ConfigReader._dnBucketName = baseConfig.Get("BUCKET");
        }

        public static string DnPdfOutPutPath
        {
            get
            {
                return ConfigReader._dnPdfOutPutPath;
            }
        }


        public static string DnBucketName
        {
            get { return ConfigReader._dnBucketName; }
        }
    }
}
