using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aliyun.OpenServices;
using Aliyun.OpenServices.OpenStorageService;
using System.IO;

namespace MonoScmPrinterService.Helper
{
    public class AliOssHelper
    {
        private static string _access_id = "VDXgx2g1F7gZe8SY";
        private static string _access_key = "cVJoHKSh377Al7il90VuQD7Fo1GiPG";
        public static void UploadFile(string bucketName, string key, string fileName,string contentType)
        {
            using (FileStream fs = File.Open(fileName, FileMode.Open))
            {
                ObjectMetadata meta = new ObjectMetadata() { ContentType =contentType };
                GetOssClient().PutObject(bucketName, key, fs, meta);
            }
        }

        private static OssClient GetOssClient()
        {
            return new OssClient( _access_id, _access_key);
        }
    }
}
