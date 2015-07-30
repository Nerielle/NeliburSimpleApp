using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract]
    public class AddToValueInMemoryRequest : BaseRequest
    {
        [DataMember]
        public int Value { get; set; }
    }
}