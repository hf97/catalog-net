using System.ComponentModel.DataAnnotations;

namespace catalog_net.Dtos
{
    public class UpdateItemDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1,100)]
        public decimal Price { get; init; }
    }
}
