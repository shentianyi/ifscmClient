using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Brilliantech.MonoScmPrinter.MethodTip
{
    public class R
    {
        public static void RR(){
            string json = "\"created_at\":\"1382-06-18T18:00:00+08:05\"";
            Regex reg = new Regex(@"created_at:w+");
         Console.WriteLine(   Regex.Replace(json, @"created_at:w+", "[$1]"));

         string j = "aboooaboooab";
         Console.WriteLine(j.IndexOf("ab"));

        }
    }
}
