using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Aliyun.OpenServices.OpenStorageService;

namespace Brilliantech.MonoScmPrinter.BaseCL.Utilities.AliOssUtil
{
    public class AliOssUtil
    {
        private static string _access_id = "VDXgx2g1F7gZe8SY";
        private static string _access_key = "cVJoHKSh377Al7il90VuQD7Fo1GiPG";

        public static void UploadFile(string bucketName, string key, string filePath, string contentType)
        {
            using (FileStream fs = File.Open(filePath, FileMode.Open))
            {
                ObjectMetadata meta = new ObjectMetadata() { ContentType = contentType };
                GetOssClient().PutObject(bucketName, key, fs, meta);
            }
        }

        public static void DownLoadFile(string bucketName, string key, string filePath)
        {
            using (OssObject result = GetOssClient().GetObject(bucketName, key))
            {
                using (Stream stream = result.Content)
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        //stream.CopyTo(fs);
                        byte[] buffer = new byte[1024];
                        int byteRead;
                        while ((byteRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fs.Write(buffer, 0, byteRead);
                        }
                    }
                }
            }
        }

        private static OssClient GetOssClient()
        {
            return new OssClient(_access_id, _access_key);
        }
    }
}
