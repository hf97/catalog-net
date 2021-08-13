using Catalog.Entities;
using catalog_net.Dtos;
using catalog_net.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog_net.Controllers
{
    // GET /items
    [ApiController]
    [Route("[controller]")] // because the name is the same, or use the route explicity [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        // GET /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItemsAsync().Select(item => item.AsDto());
            return items;
        }

        // GET /items/id
        [HttpGet("{id}")]
        // Action result because we either return a item or a error notfound
        // if we only returned Item no need for this
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item.AsDto());
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        // PUT /items/id
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            // copy of existingItem with the new values
            Item updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price,
            };

            repository.UpdateItemAsync(updatedItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            repository.DeleteItemAsync(id);

            return NoContent();
        }
    }
}
