using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract]
    public class GetSummRequest
    {
        [DataMember]
        public int  FirstValue { get; private set; }
        [DataMember]
        public int SecondValue { get; private set; }

        public GetSummRequest(int first, int second)
        {
            FirstValue = first;
            SecondValue = second;
        }
    }
}