using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Brilliantech.MonoScmPrinter.ClientCL
{
    public enum NetProxyType
    {
        NoProxy = 100,
        WebBrowserSettingProxy = 200
    }
    public class NetProxy
    {
        public static NetProxyType GetNetProxyType(int type)
        {
            return (NetProxyType)type;
        }

        public static HttpWebRequest SetHttpWebRequestProxy(HttpWebRequest req)
        {
            switch (SettingConfig.NetProxyType)
            {
                case NetProxyType.NoProxy:
                    return req;
                case NetProxyType.WebBrowserSettingProxy:
                    req.Proxy = WebRequest.GetSystemWebProxy();
                    return req;
                default:
                    return req;
            }
        }
    }
}
