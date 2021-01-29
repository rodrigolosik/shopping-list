using MongoDB.Driver;
using ShoppingList.Domain.Models;
using ShoppingList.Domain.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingList.Repository.Shoppings
{
    public class ShoppingRepository : IShoppingRepository
    {
        private readonly IMongoCollection<Shopping> _shoppings;
        public ShoppingRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _shoppings = database.GetCollection<Shopping>(settings.ProductsCollectionName);
        }

        public async Task<Shopping> Create(Shopping shopping)
        {
            await _shoppings.InsertOneAsync(shopping);
            return shopping;
        }
        public async Task<Shopping> Get(string id) => await _shoppings.Find<Shopping>(shopping => shopping.Id == id).FirstOrDefaultAsync();
        public async Task<List<Shopping>> Get() => await _shoppings.Find(shopping => true).ToListAsync();
    }
}
