using ShoppingList.Domain.Models;
using ShoppingList.Repository.Products;
using System.Collections.Generic;

namespace ShoppingList.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public Product Create(Product product)
        {
            return _repo.Create(product);
        }

        public Product Get(string id)
        {
            return _repo.Get(id);
        }

        public List<Product> Get()
        {
            return _repo.Get();
        }

        public void Remove(Product productIn)
        {
            _repo.Remove(productIn);
        }

        public void Remove(string id)
        {
            _repo.Remove(id);
        }

        public void Update(string id, Product productIn)
        {
            _repo.Update(id, productIn);
        }
    }
}
