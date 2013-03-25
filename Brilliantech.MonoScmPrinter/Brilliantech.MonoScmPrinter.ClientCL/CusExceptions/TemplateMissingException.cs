using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brilliantech.MonoScmPrinter.ClientCL.CusExceptions
{
    public class RestHostMissingException : Exception
    {
        public RestHostMissingException(Exception e) : base("网络连接错误，请核实网络状况！",e) { }
    }
}
