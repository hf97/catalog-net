using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace catalog_net.Repositories
{
    public interface IItemsRepository
    {
        // task makes it async, it returns a task insted of the item 
        Task<Item> GetItemAsync(Guid id);

        Task<IEnumerable<Item>> GetItemsAsync();
        
        Task CreateItemAsync(Item item);

        Task UpdateItemAsync(Item item);

        Task DeleteItemAsync(Guid id);
    }
}