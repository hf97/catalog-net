using System;

namespace catalog_net.Dtos
{
    // type of item that api return, the contract it has
    public record ItemDto
    {
        // init insted of set because we want immutable propriety
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
