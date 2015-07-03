using Contracts;

namespace Nelibur.Commands
{
    public class AddToValueInMemoryCommand:ICommand<AddToValueInMemoryRequest>
    {
        public void Execute(AddToValueInMemoryRequest request)
        {
            Memory.ValueInMemory += request.Value;
        }
    }
}