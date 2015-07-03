using Contracts;

namespace Nelibur.Queries
{
    public interface IQuery<in T> where T: BaseRequest
    {
        IntResponse Ask(T request);
    }
}