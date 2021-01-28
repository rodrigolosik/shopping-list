using ShoppingList.Domain.Models;
using System.Collections.Generic;

namespace ShoppingList.Service.Products
{
    public interface IProductService
    {
        void Remove(Product productIn);
        void Remove(string id);
        void Update(string id, Product productIn);
        Product Create(Product product);
        Product Get(string id);
        List<Product> Get();
    }
}
