using System.ServiceModel;
using MonoScmPrinterService.DataModel;

namespace MonoScmPrinterService
{
    [ServiceContract]
    public interface IGenDNPdfService
    {
        [OperationContract]
        ProcessMessage GenerateDnPdf(string template, string dataJson, string dnKey);
    }
}
