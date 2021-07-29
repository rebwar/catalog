using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void DeleteItem(Guid id)
        {
            var existingItem = items.FindIndex(c => c.Id == id);
            items.RemoveAt(existingItem);
        }

        public void EditItem(Item item)
        {
            var index = items.FindIndex(x => x.Id == item.Id);
            items[index] = item;
        }

        public Item GetItem(Guid id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Item> GetItems()
        {
            return items.ToList();
        }
    }
}