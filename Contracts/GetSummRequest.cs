using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract]
    public class GetSummRequest:BaseRequest
    {
        public GetSummRequest(int first, int second)
        {
            FirstValue = first;
            SecondValue = second;
        }

        [DataMember]
        public int FirstValue { get; private set; }

        [DataMember]
        public int SecondValue { get; private set; }
    }
}