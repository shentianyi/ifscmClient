using System.Runtime.Serialization;

namespace MonoScmPrinterService.DataModel
{
    [DataContract]
    public class MessageBase
    {
        [DataMember]
        public bool Result { get; set; }
        [DataMember]
        public string Content { get; set; }
    }
}
