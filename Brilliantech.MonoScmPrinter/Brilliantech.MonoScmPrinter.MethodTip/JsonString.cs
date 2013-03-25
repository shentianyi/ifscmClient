using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization.Json;


namespace Brilliantech.MonoScmPrinter.MethodTip
{
    public static class JSON
    {
        public static T parse<T>(string jsonString)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(ms);
            } 
        }

        public static string stringify(object jsonObject)
        {
            using (var ms = new MemoryStream())
            {
                new DataContractJsonSerializer(jsonObject.GetType()).WriteObject(ms, jsonObject);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        } 
    }

    public static  class JSONTest
    {
        public static void TestIt()
        {

            string jsonString = JSON.stringify(new[] { new Person() { Name = "Jack", Age = 12 }, new Person() { Name = "Tom", Age = 13 } });
           jsonString= jsonString.Replace("Age", "age");
            Console.WriteLine(jsonString);
            Person jack = JSON.parse<Person[]>(jsonString)[1];
            Console.WriteLine(jack.Age);
        }

        public static void TestDic() {

            string jsonString = JSON.stringify(new[] { new Dic() { Key = "Age", Value = "12" }, new Dic() { Key = "Name", Value = "Jack" } });
            Console.WriteLine(jsonString);
            Dictionary<string, string> dic = JSON.parse<Dictionary<string, string>>(jsonString);
            foreach (KeyValuePair<string, string> k in dic)
            {
                Console.WriteLine("{0}:{1}",k.Key,k.Value);
            }

        }
    }
}
