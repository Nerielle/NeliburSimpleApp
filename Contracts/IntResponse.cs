using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract]
    public class IntResponse:BaseResponse
    {
        [DataMember]
        public int Result { get; set; }
    }
}