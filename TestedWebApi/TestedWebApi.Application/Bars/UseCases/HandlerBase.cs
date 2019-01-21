using TestedWebApi.Domain.Shared;

namespace TestedWebApi.Application.Bars.UseCases
{
    public class HandlerBase<T>
        where T : BaseEntity
    {
        protected IRepository<T> Repository;

        public HandlerBase(IRepository<T> repository) =>
            Repository = repository;
    }
}