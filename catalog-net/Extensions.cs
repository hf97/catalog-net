
using Catalog.Entities;
using catalog_net.Dtos;

namespace catalog_net
{
    public static class Extensions
    {
        // extension is static
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }
    }
}
