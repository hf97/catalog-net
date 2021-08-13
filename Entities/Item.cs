using System;

namespace Catalog.Entities
{
    public record Item
    {
        // init insted of set because we want immutable propriety
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}