using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;

namespace Brilliantech.ScmPrinterWindowsService
{
    public partial class ScmPrinterWindowsService : ServiceBase
    {
        public const string source = "brilliantech.scmprinter.log.source";
        public const string logSource = "brilliantech.scmprinter.log.source.new";
        public static ServiceHost scmPrinterService;
        public ScmPrinterWindowsService()
        {
            InitializeComponent();
            if (!System.Diagnostics.EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, logSource);
            }
            eventLogBSCMPrinter.Source = source;
            eventLogBSCMPrinter.Log = logSource;
            scmPrinterService = new ServiceHost(typeof(MonoScmPrinterService.GenDNPdfService));
        }

        protected override void OnStart(string[] args)
        {
            writeLog("On Start");
            try
            {
                if (scmPrinterService != null)
                {
                    scmPrinterService.Open();
                    writeLog("****** HOST IS ON ********");
                }
            }
            catch (Exception e)
            {
                writeLog(e.Message);
            }
        }

        protected override void OnStop()
        {
            if (scmPrinterService != null)
                scmPrinterService.Close();
            writeLog("On Stop");
        }
        protected override void OnPause()
        {
            if (scmPrinterService != null)
                scmPrinterService.Close();
            writeLog("On Pause");
            base.OnPause();
        }

        private void writeLog(string log)
        {
            eventLogBSCMPrinter.WriteEntry(new DateTime().ToString("yyyy-MM-dd hh:MM:sss"));
            eventLogBSCMPrinter.WriteEntry(log);
        }
    }
}
