using ShoppingList.Domain.Models;
using ShoppingList.Repository.Shoppings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingList.Service.Shoppings
{
    public class ShoppingService : IShoppingService
    {
        private readonly IShoppingRepository _repo;
        public ShoppingService(IShoppingRepository repo) => _repo = repo;
        public async Task<Shopping> Create(Shopping product) => await _repo.Create(product);
        public async Task<Shopping> Get(string id) => await _repo.Get(id);
        public async Task<List<Shopping>> Get() => await _repo.Get();
    }
}
