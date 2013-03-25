using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Brilliantech.MonoScmPrinter.ClientCL.CusExceptions
{
    public class TemplateMissingException : WebException
    {
        public TemplateMissingException() : base("打印模版不存在") { }
    }
}
