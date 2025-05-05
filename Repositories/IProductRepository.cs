using Rentify.Models;

namespace Rentify.Repositories
{
    public interface IProductRepository
    {

        IEnumerable<Products> GetAllProducts();

        Products GetProductById(int id);

        Products GetProductByName(string name);

        int AddProduct(Products prod);

        int UpdateProduct(Products prod);

        int DeleteProduct(int id);



    }
}
