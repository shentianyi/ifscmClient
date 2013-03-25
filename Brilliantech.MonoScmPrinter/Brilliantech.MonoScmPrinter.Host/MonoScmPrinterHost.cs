using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Brilliantech.MonoScmPrinter.Host
{
    class MonoScmPrinterHost
    {
        static void Main(string[] args)
        {
            ServiceHost genDnPdfServiceHost = null;
            try
            {
                //if (Environment.GetEnvironmentVariable("MONO_STRICT_MS_COMPLIANT") != "yes")
                //{
                //    Environment.SetEnvironmentVariable("MONO_STRICT_MS_COMPLIANT", "yes");
                //    Console.WriteLine("设置环境变量“MONO_STRICT_MS_COMPLIANT”为Yes！");
                //}
                genDnPdfServiceHost = new ServiceHost(typeof(MonoScmPrinterService.GenDNPdfService));
                genDnPdfServiceHost.Open();
                Console.WriteLine("****** HOST IS ON ********");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
}