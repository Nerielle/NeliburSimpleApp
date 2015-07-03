using Contracts;
using Nelibur.ServiceModel.Services.Operations;

namespace Nelibur
{
    public class Calculator : IGet<GetSummRequest>
    {
        public object Get(GetSummRequest request)
        {
            return new IntResponse {Result = request.FirstValue + request.SecondValue};
        }
    }
}