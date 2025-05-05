using Rentify.Models;
using Rentify.Repositories;

namespace Rentify.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repo;

        public ProductService(IProductRepository repo)
        {
            this.repo = repo;
            
        }
        public int AddProduct(Products prod)
        {
            return repo.AddProduct(prod);
        }

        public int DeleteProduct(int id)
        {
            return repo.DeleteProduct(id);
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return repo.GetAllProducts();
        }

        public Products GetProductById(int id)
        {
            return repo.GetProductById(id);
        }

        public Products GetProductByName(string name)
        {
            return repo.GetProductByName(name);
        }

        public int UpdateProduct(Products prod)
        {
            return repo.UpdateProduct(prod);
        }
    }
}
