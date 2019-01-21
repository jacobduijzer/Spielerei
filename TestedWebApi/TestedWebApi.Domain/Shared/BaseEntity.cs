using System;

namespace TestedWebApi.Domain.Shared
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public BaseEntity ToList()
        {
            throw new NotImplementedException();
        }
    }
}