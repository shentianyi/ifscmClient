using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brilliantech.MonoScmPrinter.MethodTip
{
   public class CException
    {
       public void DOException()
       {
           try
           {
               string s = null;
              MyFn(s);
           }

           // Most specific:
           catch (ArgumentNullException e)
           {
               Console.WriteLine("{0} First exception caught.", e);
               throw e;
           }

           // Least specific:
           catch (Exception e)
           {
               Console.WriteLine("{0} Second exception caught.", e);
           }
       }
       public void MyFn(string s)
       {
           if (s == null)
               throw new ArgumentNullException();
       }  
    }
}
