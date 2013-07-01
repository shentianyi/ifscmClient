using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.MonoScmPrinter.BaseCL.Utilities.AliOssUtil;
using Brilliantech.MonoScmPrinter.ClientCL;
using System.IO;

namespace Brilliantech.MonoScmPrinter.Client
{
    public class Downloader
    {
        public static void DownLoadTemplate(string[] files)
        {
            foreach (string file in files)
            {
                AliOssUtil.DownLoadFile(BaseConfig.TemplateBucket, file,
                     Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SettingConfig.TemplatePath, file));
            }
        }
    }
}
