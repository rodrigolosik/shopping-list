using ShoppingList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingList.Repository.Shoppings
{
    public interface IShoppingRepository
    {
        Task<Shopping> Create(Shopping shopping);
        Task<Shopping> Get(string id);
        Task<List<Shopping>> Get();
    }
}
