using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestedWebApi.Domain.Bars;
using TestedWebApi.Domain.Shared;

namespace TestedWebApi.Application.Bars.UseCases
{
    public class UpdateBarHandler : HandlerBase<Bar>, IRequestHandler<UpdateBarRequest>
    {
        public UpdateBarHandler(IRepository<Bar> repository)
            : base(repository)
        { }

        public async Task<Unit> Handle(UpdateBarRequest request, CancellationToken cancellationToken)
        {
            Repository.Update(request.Bar);
            return await Task.FromResult(default(Unit));
        }
    }
}