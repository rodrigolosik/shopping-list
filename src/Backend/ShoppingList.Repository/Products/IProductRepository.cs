using ShoppingList.Domain.Models;
using System.Collections.Generic;

namespace ShoppingList.Repository.Products
{
    public interface IProductRepository
    {
        void Remove(Product productIn);
        void Remove(string id);
        void Update(string id, Product productIn);
        Product Create(Product product);
        Product Get(string id);
        List<Product> Get();
    }
}
