using TestedWebApi.Domain.Shared;

namespace TestedWebApi.Domain.Bars
{
    public class Bar : BaseEntity
    {
        public string Name { get; set; }

        public string City { get; set; }

        public bool IsFavorite { get; set; }
    }
}