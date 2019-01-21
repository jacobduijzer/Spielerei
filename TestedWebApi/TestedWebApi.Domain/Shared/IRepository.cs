using LinqBuilder.Core;
using System.Collections.Generic;

namespace TestedWebApi.Domain.Shared
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        List<T> GetAll();

        T GetById(int id);

        T GetItem(ISpecification<T> specification);

        void Update(T updatedItem);
    }
}