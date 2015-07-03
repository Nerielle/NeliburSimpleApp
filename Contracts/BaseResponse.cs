using System.Runtime.Serialization;

namespace Contracts
{
    [KnownType(typeof(IntResponse))]
    [DataContract]
    public class BaseResponse
    {
    }
}