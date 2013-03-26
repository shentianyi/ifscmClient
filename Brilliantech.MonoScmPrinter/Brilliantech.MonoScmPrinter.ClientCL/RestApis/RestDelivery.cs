using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.MonoScmPrinter.BaseCL;
using System.Net;
using Brilliantech.MonoScmPrinter.ClientCL.Model;
using Brilliantech.ReportGenConnector;
using Brilliantech.MonoScmPrinter.ClientCL.IRestApis;

namespace Brilliantech.MonoScmPrinter.ClientCL.RestApis
{
    public class RestDelivery : IRestDelivery
    {
        public List<string> DnList(int staffId)
        {
            byte[] bytes = ParameterHelper.generateDnSingleParameterByte(staffId.ToString(), "staffId");
            HttpWebRequest req = RestRequest.CreateWebRequest(BaseConfig.DnPrintQueueListUrl, RequestMethod.Post, bytes.Length);
            return JSON.parse<List<string>>(RestRequest.GetResponse(req, bytes));
        }

        public ReturnMsg<string> RemoveFromPrintQueue(string dnKey)
        {
            byte[] bytes = ParameterHelper.generateDnSingleParameterByte(dnKey);
            HttpWebRequest req = RestRequest.CreateWebRequest(BaseConfig.DnRemoveFromPrintQueueAction, RequestMethod.Post, bytes.Length);
            return JSON.parse<ReturnMsg<string>>(RestRequest.GetResponse(req, bytes));
        }

        public List<DeliveryPackage> DnPackageList(string dnKey)
        {
            byte[] bytes = ParameterHelper.generateDnSingleParameterByte(dnKey);
            HttpWebRequest req = RestRequest.CreateWebRequest(BaseConfig.DnPackageListAction, RequestMethod.Post, bytes.Length);
            return JSON.parse<List<DeliveryPackage>>(RestRequest.GetResponse(req, bytes));
        }

        public List<DeliveryItem> DnItemList(string dnKey)
        {
            byte[] bytes = ParameterHelper.generateDnSingleParameterByte(dnKey);
            HttpWebRequest req = RestRequest.CreateWebRequest(BaseConfig.DnItemListAction, RequestMethod.Post, bytes.Length);
            return JSON.parse<List<DeliveryItem>>(RestRequest.GetResponse(req, bytes));
        }

        public PrintData DnItemPrintData(string dnKey,int templateType)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("dnKey", dnKey);
            parameters.Add("type", templateType.ToString());
            byte[] bytes = ParameterHelper.generateMutiParametersByte(parameters);
            HttpWebRequest req = RestRequest.CreateWebRequest(BaseConfig.DnItemPrintDataAction, RequestMethod.Post, bytes.Length);
            return JSON.parse<PrintData>(RestRequest.GetResponse(req, bytes));
        }


        public PrintData DnItemPrintData(string[] diKeys,int templateType)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("diKeys", string.Join(",", diKeys));
            parameters.Add("type", templateType.ToString());
            byte[] bytes = ParameterHelper.generateMutiParametersByte(parameters);
            HttpWebRequest req = RestRequest.CreateWebRequest(BaseConfig.DnItemPrintDataAction, RequestMethod.Post, bytes.Length);
            return JSON.parse<PrintData>(RestRequest.GetResponse(req, bytes));
        }

        public List<EnumItem> ClientPackTemplate()
        {
            HttpWebRequest req = RestRequest.CreateWebRequest(BaseConfig.DnClientPackTemplateAction, RequestMethod.Post, 0);
            return JSON.parse<List<EnumItem>>(RestRequest.GetResponse(req, new byte[0]));
        }


        public ReturnMsg<string> DnArrive(int orgId, string dnKey)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("dnKey", dnKey);
            parameters.Add("org_id", orgId.ToString());
            byte[] bytes = ParameterHelper.generateMutiParametersByte(parameters);
            HttpWebRequest req = RestRequest.CreateWebRequest(BaseConfig.DnArriveAction, RequestMethod.Post, bytes.Length);
            return JSON.parse<ReturnMsg<string>>(RestRequest.GetResponse(req, bytes));
        }
    }
}
