using System;
using MonoScmPrinterService.DataModel;
using Brilliantech.MonoScmPrinter.BaseCL;
using MonoScmPrinterService.Helper;
using MonoScmPrinterService.IHelper;
using ICSharpCode.SharpZipLib.Zip;
using System.Runtime.InteropServices;
using Brilliantech.ReportGenConnector;

namespace MonoScmPrinterService
{
    public class GenDNPdfService : IGenDNPdfService
    {
        public ProcessMessage GenerateDnPdf(string template, string dataJson, string dnKey)
        {
            ProcessMessage msg = new ProcessMessage() { Result = false };
            try
            {
                Console.WriteLine("*******");
                Console.WriteLine(template);
                Console.WriteLine(dnKey);
                Console.WriteLine("*******");
                string fileName = Guid.NewGuid().ToString() + ".pdf";
                string folderPath = ConfigReader.DnPdfOutPutPath;
                IGenPrinter dnPdfPrinter = new GenPrinterBase(folderPath, template);
                dnPdfPrinter.Print(JSON.parse<RecordSet>(dataJson), fileName);
                AliOssHelper.UploadFile(ConfigReader.DnBucketName, fileName, dnPdfPrinter.GetFilePath(), "application/pdf");
                msg.Result = true;
                msg.Content = fileName;
            }
            catch (Exception e)
            {
                msg.Content = e.Message;
            }
            return msg;
        }
    }
}
