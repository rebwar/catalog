using System;
using System.Collections.Generic;
using catalog.Entities;
using MongoDB.Driver;

namespace catalog.Repositories
{
    public class MongoDbItemRepository : IItemRepository
    {
        private const string databaseName="Catalog";
        private const string collectionName="items";
        private readonly IMongoCollection<Item> itemsCollection;
        public MongoDbItemRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database=mongoClient.GetDatabase(databaseName);
            itemsCollection=database.GetCollection<Item>(collectionName);
            
        }
        public void CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public void EditItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}