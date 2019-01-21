using System.Collections.Generic;

namespace TestedWebApi.Domain.Shared
{
    public interface IDatabase<T>
    {
        List<T> Items { get; set; }
    }
}