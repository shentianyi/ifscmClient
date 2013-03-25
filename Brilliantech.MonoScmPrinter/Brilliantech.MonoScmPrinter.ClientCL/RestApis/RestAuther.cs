using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.MonoScmPrinter.ClientCL.Model;
using System.Net;
using System.IO;
using Brilliantech.MonoScmPrinter.BaseCL;
using Brilliantech.MonoScmPrinter.ClientCL.IRestApis;
using Brilliantech.MonoScmPrinter.ClientCL.CusExceptions;

namespace Brilliantech.MonoScmPrinter.ClientCL.RestApis
{
    public class RestAuther : IRestAuther
    {
        public ReturnMsg<LoginInfo> Login(string staffNr, string pass)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("staffNr", staffNr);
            parameters.Add("password", pass);
            string parameter = RestRequest.CreateFormattedParams(parameters);
            byte[] bytes = Encoding.UTF8.GetBytes(parameter);
            RestRequest restReq = new RestRequest();
            HttpWebRequest req = RestRequest.CreateWebRequest(BaseConfig.ApiLoginUrl, RequestMethod.Post, bytes.Length);
            return JSON.parse<ReturnMsg<LoginInfo>>(RestRequest.GetResponse(req, bytes));
        }
    }
}