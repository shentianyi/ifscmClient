using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brilliantech.MonoScmPrinter.ClientCL
{
    public class ParameterHelper
    {
        public static byte[] generateDnSingleParameterByte(string paramValue, string paramName = "dnKey")
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add(paramName, paramValue);
            string parameter = RestRequest.CreateFormattedParams(parameters);
            return Encoding.UTF8.GetBytes(parameter);
        }

        public static byte[] generateMutiParametersByte(Dictionary<string, string> parameters)
        {
            string parameter = RestRequest.CreateFormattedParams(parameters);
            return Encoding.UTF8.GetBytes(parameter);
        }
    }
}
