using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using catalog.Entities;

namespace catalog.Repositories
{
    public interface IItemRepository
    {
         Task<IEnumerable<Item>> GetItemsAsync();
         Task<Item> GetItemAsync(Guid id);
         Task EditItemAsync(Item item);
         Task CreateItemAsync(Item item);
         Task DeleteItemAsync(Guid id);
    }
}