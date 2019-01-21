using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestedWebApi.Domain.Bars;
using TestedWebApi.Domain.Shared;

namespace TestedWebApi.Application.Bars.UseCases
{
    public class BarsHandler : HandlerBase<Bar>, IRequestHandler<BarsRequest, BarsResponse>
    {
        public BarsHandler(IRepository<Bar> repository)
            : base(repository) { }

        public async Task<BarsResponse> Handle(BarsRequest request, CancellationToken cancellationToken)
        {
            var results = Repository.GetAll();
            var response = new BarsResponse(results);

            return await Task.FromResult(response);
        }
    }
}