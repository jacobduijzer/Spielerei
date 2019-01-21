﻿using TestedWebApi.Domain.Shared;

namespace TestedWebApi.Domain.Beers
{
    public class Beer : BaseEntity
    {
        public string Name { get; set; }

        public bool IsFavorite { get; set; }
    }
}