using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract]
    public class SaveInMemoryRequest : BaseRequest
    {
        [DataMember]
        public int Value { get; set; }
    }
}