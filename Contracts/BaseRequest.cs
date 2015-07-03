using System.Runtime.Serialization;

namespace Contracts
{
    [KnownType(typeof(GetSummRequest))]
    [KnownType(typeof(CleanMemoryRequest))]
    [KnownType(typeof(SaveInMemoryRequest))]
    [KnownType(typeof(ReadFromMemoryRequest))]
    [DataContract]
    public class BaseRequest
    {
         
    }
}