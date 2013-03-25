using Brilliantech.ReportGenConnector;
namespace MonoScmPrinterService.IHelper
{
    public interface IGenPrinter
    {
        void Print(RecordSet data,string fileName);
        string GetFilePath();
    }
}
