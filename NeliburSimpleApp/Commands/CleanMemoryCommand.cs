using Contracts;

namespace Nelibur.Commands
{
    public class CleanMemoryCommand:ICommand<CleanMemoryRequest>
    {
        public void Execute(CleanMemoryRequest request)
        {
            Memory.ValueInMemory = 0;
        }
    }
}