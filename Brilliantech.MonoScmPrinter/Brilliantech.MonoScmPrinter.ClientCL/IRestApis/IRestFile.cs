using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brilliantech.MonoScmPrinter.ClientCL.IRestApis
{
    public interface IRestFile
    {
        string[] GetUpdatedTemplate(int orgId);
    }
}
