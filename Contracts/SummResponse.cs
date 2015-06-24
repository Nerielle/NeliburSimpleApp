using System.Runtime.Serialization;

namespace Nelibur
{
    [DataContract]
    public class SummResponse
    {
        [DataMember]
        public int Result { get; set; }
 
    }
}