using Nelibur.ServiceModel.Services.Operations;

namespace Nelibur
{
    public class Calculator:IGet<GetSummRequest>
    {
        public object Get(GetSummRequest request)
        {
            return request.FirstValue + request.SecondValue;
        }
    }
}