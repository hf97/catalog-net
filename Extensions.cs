
using Catalog.Entities;
using catalog_net.Dtos;

namespace catalog_net
{
    public static class Extensions
    {
        // extension is static
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate,
            };
        }
    }
}
