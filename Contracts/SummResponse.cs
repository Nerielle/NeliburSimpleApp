using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract]
    public class SummResponse
    {
        [DataMember]
        public int Result { get; set; }
    }
}