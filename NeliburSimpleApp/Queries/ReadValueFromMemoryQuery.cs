using Contracts;

namespace Nelibur.Queries
{
    public class ReadValueFromMemoryQuery : IQuery<ReadFromMemoryRequest>
    {
        public IntResponse Ask(ReadFromMemoryRequest request)
        {
            return new IntResponse {Result = Memory.ValueInMemory};
        }
    }
}