using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.MonoScmPrinter.BaseCL.Utilities.ConfigUtil;
using System.Net;
using System.Web;
using System.IO;
using Brilliantech.MonoScmPrinter.ClientCL.CusExceptions;

namespace Brilliantech.MonoScmPrinter.ClientCL
{
    public class RestRequest
    {
        public static HttpWebRequest CreateWebRequest(string endpoint, string method, int content_length)
        {            
            HttpWebRequest req = WebRequest.Create(endpoint) as HttpWebRequest;
            req.Method = method;
            req.ContentLength = content_length;
            req.Headers.Add("Authorization", Convert.ToBase64String(new System.Text.ASCIIEncoding().GetBytes("scmdddd")));
            req.ContentType = "application/x-www-form-urlencoded";
            return req;
        }

        public static string GetResponse(HttpWebRequest req, byte[] bytes)
        {
            try
            {
                using (Stream stream = req.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
                using (HttpWebResponse res = req.GetResponse() as HttpWebResponse)
                {
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream stream = res.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                return reader.ReadToEnd();
                            }
                        }
                    }
                    else
                    {
                        string message = String.Format("POST failed. Received HTTP {0}", res.StatusCode);
                        throw new ApplicationException(message);
                    }
                }
            }
            catch(WebException e)
            {
                throw new RestHostMissingException(e);
            }
        }

        public static string CreateFormattedParams(Dictionary<string, string> parameters)
        {
            StringBuilder paramBuilder = new StringBuilder();
            int count = 0;
            foreach (var value in parameters)
            {
                paramBuilder.AppendFormat("{0}={1}", value.Key, HttpUtility.UrlEncode(value.Value));
                if (count != parameters.Count - 1)
                {
                    paramBuilder.Append("&");
                }
                count++;
            }
            return paramBuilder.ToString();
        }
    }

    public struct RequestMethod
    {
        private static string _get;
        private static string _post;
        static RequestMethod()
        {
            RequestMethod._get = "GET";
            RequestMethod._post = "POST";
        }
        public static string Get { get { return RequestMethod._get; } }
        public static string Post { get { return RequestMethod._post; } }
    }
}
