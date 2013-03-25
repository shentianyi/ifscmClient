using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.MonoScmPrinter.ClientCL.Model;

namespace Brilliantech.MonoScmPrinter.ClientCL.IRestApis
{
   public interface IRestAuther
    {
       /// <summary>
       /// user login 
       /// </summary>
       /// <param name="staffNr">staff nr</param>
       /// <param name="pass">password</param>
       /// <returns>login info</returns>
       ReturnMsg<LoginInfo> Login(string staffNr, string pass);
    }
}
