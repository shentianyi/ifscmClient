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
           //             RecordSet rs = new RecordSet(); 
           // RecordData rd = new RecordData();
           // rd.Add("DNr", "2323");
           // rd.Add("SendData","2323232");
           // rs.Add(rd);
           // rs.Add(rd);
           //string s= JSON.stringify(rs);
           //Console.WriteLine(s);
            //string staffNr = "leoni55"; // TODO: 初始化为适当的值
            //string pass = "leoni"; // TODO: 初始化为适当的值 
            //ReturnMsg<LoginInfo> actual;
            //IRestAuther auther = new RestAuther();
            //actual = auther.Login(staffNr, pass); ;
            ////Console.WriteLine(actual.@object.orgName);
            //Console.WriteLine(actual.result);
            try
            {
                new CException().DOException();
            }
            catch (FieldAccessException e) {
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
