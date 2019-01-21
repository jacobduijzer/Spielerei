using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestedWebApi.Domain.Bars;
using TestedWebApi.Domain.Shared;

namespace TestedWebApi.Application.Bars.UseCases
{
    public class BarHandler : HandlerBase<Bar>, IRequestHandler<BarRequest, BarResponse>
    {
        public BarHandler(IRepository<Bar> repository)
            : base(repository)
        {
        }

        public async Task<BarResponse> Handle(BarRequest request, CancellationToken cancellationToken)
        {
            var result = Repository.GetItem(request.Specification);
            var response = new BarResponse(result);

            return await Task.FromResult(response);
        }
    }
}