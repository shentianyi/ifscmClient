using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brilliantech.MonoScmPrinter.MethodTip
{

    public interface IPlante {
        void GetName();
    }
    public class Earth : IPlante {
        public void GetName()
        {
            Console.WriteLine("i am earth");
        }
    }
}
