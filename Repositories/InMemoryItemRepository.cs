using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalog.Entities;

namespace catalog.Repositories
{
    public class InMemoryItemRepository : IItemRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreateDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreateDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreateDate = DateTimeOffset.UtcNow }
        };

        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);
           await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var existingItem = items.FindIndex(c => c.Id == id);
            items.RemoveAt(existingItem);
            await Task.CompletedTask;
        }

        public async Task EditItemAsync(Item item)
        {
            var index = items.FindIndex(x => x.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items.ToList());
        }
    }
}