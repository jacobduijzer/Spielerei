using LinqBuilder.Core;
using System.Collections.Generic;
using System.Linq;
using TestedWebApi.Domain.Shared;

namespace TestedWebApi.Infrastructure.Shared
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly IDatabase<T> _database;

        public Repository(IDatabase<T> database) =>
            _database = database;

        public List<T> GetAll() => _database.Items;

        public T GetById(int id) =>
            _database.Items.FirstOrDefault(item => item.Id == id);

        public T GetItem(ISpecification<T> specification) =>
            _database.Items.ExeSpec(specification).FirstOrDefault();

        public void Update(T updatedItem)
        {
            var existingItem = _database.Items.FirstOrDefault(item => item.Id == updatedItem.Id);
            if (existingItem != null)
            {
                _database.Items.Remove(existingItem);
                _database.Items.Add(updatedItem);
            }
        }
    }
}