using System;
using System.Collections.Generic;
using catalog.Entities;

namespace catalog.Repositories
{
    public interface IItemRepository
    {
         IEnumerable<Item> GetItems();
         Item GetItem(Guid id);
         void EditItem(Item item);
         void CreateItem(Item item);
         void DeleteItem(Guid id);
    }
}