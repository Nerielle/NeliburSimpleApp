using Contracts;

namespace Nelibur.Commands
{
    public interface ICommand<in T> where T : BaseRequest
    {
        void Execute(T request);
    }
}