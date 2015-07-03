using Contracts;
using Nelibur.Commands;
using Nelibur.Queries;
using Nelibur.ServiceModel.Services.Operations;

namespace Nelibur
{
    public class Calculator : IGet<GetSummRequest>,
        IGet<ReadFromMemoryRequest>,
        IPostOneWay<SaveInMemoryRequest>,
        IPostOneWay<CleanMemoryRequest>
    {
        public object Get(GetSummRequest request)
        {
            return new IntResponse {Result = request.FirstValue + request.SecondValue};
        }

        public object Get(ReadFromMemoryRequest request)
        {
            return new ReadValueFromMemoryQuery().Ask(request);
        }

        public void PostOneWay(SaveInMemoryRequest request)
        {
            new SaveValueCommand().Execute(request);
        }

        public void PostOneWay(CleanMemoryRequest request)
        {
            new CleanMemoryCommand().Execute(request);
        }
    }
}