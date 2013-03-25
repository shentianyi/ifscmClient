using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.MonoScmPrinter.ClientCL.Enums;

namespace Brilliantech.MonoScmPrinter.ClientCL.Model
{
   public class ReturnMsg<T>
    {
       public MsgLevel level { get; set; }
       public bool result { get; set; }
       public string content { get; set; }
       public T @object { get; set; }
    }
}
