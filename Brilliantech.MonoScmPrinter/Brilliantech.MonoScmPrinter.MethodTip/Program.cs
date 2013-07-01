using System;
using TECIT.TFORMer;
using Brilliantech.ReportGenConnector;
using Brilliantech.MonoScmPrinter.ClientCL;
using Brilliantech.MonoScmPrinter.ClientCL.RestApis;
using Brilliantech.MonoScmPrinter.ClientCL.Model;
using Brilliantech.MonoScmPrinter.ClientCL.IRestApis;

namespace Brilliantech.MonoScmPrinter.MethodTip
{
    class Program
    {
        static void Main(string[] args)
        {
          
            PingExample.PintIt("42.121.0.141");
            try
            {
                // new CException().DOException();
            }
            catch (FieldAccessException e)
            {
                Console.Write(e.Message);
            }
            catch (Exception e) {
                Console.Write(e.Message);
            
            }
            Console.Read();
        }

        public class TECITLicense
        {
            private static readonly string pf_licensee = "Mem: Cai Zhuo Information & Technology Co.,Ltd";
            private static readonly string pf_licenseKey = "45D392D071FA5767B4D85D2EE7ED7E76";
            private static readonly int pf_numberOfLicense = 1;

            private static readonly LicenseKind pf_licenseKind = LicenseKind.Developer;
            public static void Register()
            {
                TFORMer.License(pf_licensee, pf_licenseKind, pf_numberOfLicense, pf_licenseKey);
            }
        }
    }
}
