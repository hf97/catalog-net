using System;

namespace Catalog.Entities
{
    public class Item
    {
        // init insted of set because we want immutable propriety
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}