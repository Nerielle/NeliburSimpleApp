using Contracts;

namespace Nelibur.Commands
{
    public class SaveValueCommand : ICommand<SaveInMemoryRequest>
    {
        public void Execute(SaveInMemoryRequest request)
        {
            Memory.ValueInMemory = request.Value;
        }
    }
}