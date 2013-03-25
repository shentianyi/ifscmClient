using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;

namespace Brilliantech.MonoScmPrinter.MethodTip
{
    public class Zipper
    {
        public void DoZip() {
            FastZip zip = new FastZip();
            zip.CreateZip(@"D:\Soft\d.zip", @"D:\Soft\Driver", false, "");
        }
    }
}
