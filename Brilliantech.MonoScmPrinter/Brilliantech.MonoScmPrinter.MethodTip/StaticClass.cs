using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brilliantech.MonoScmPrinter.MethodTip
{
    public class StaticClass
    {
        public static string name = "hello static class";
        static StaticClass() {
            Console.WriteLine(".......");
        }
        public StaticClass() {
            Console.WriteLine("*****");
        }
        public static void GetStaticName() {
            Console.WriteLine(name);
        }
        public void GetName() {
            Console.WriteLine(name);
        }
    }


}
