using ShoppingList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingList.Service.Shoppings
{
    public interface IShoppingService
    {
        Task<Shopping> Create(Shopping product);
        Task<Shopping> Get(string id);
        Task<List<Shopping>> Get();
    }
}
