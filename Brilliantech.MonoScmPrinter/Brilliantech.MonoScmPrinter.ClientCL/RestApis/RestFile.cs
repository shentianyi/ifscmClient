using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.MonoScmPrinter.ClientCL.IRestApis;
using System.Net;
using Brilliantech.MonoScmPrinter.BaseCL;

namespace Brilliantech.MonoScmPrinter.ClientCL.RestApis
{
    public class RestFile : IRestFile
    {
        public string[] GetUpdatedTemplate(int orgId)
        {
            byte[] bytes = ParameterHelper.generateDnSingleParameterByte(orgId.ToString(),"orgId");
            HttpWebRequest req = RestRequest.CreateWebRequest(BaseConfig.UpdatePrinterTemplateAction, RequestMethod.Post, bytes.Length);
            return JSON.parse<string[]>(RestRequest.GetResponse(req, bytes));  
        }
    }
}
