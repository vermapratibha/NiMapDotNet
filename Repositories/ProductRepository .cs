using Rentify.Data;
using Rentify.Models;
using Rentify.Repositories;

public class ProductRepository : IProductRepository
{

    private readonly ApplicationDbContext db;

    public ProductRepository(ApplicationDbContext db)
    {
        this.db = db;
    }
    public int AddProduct(Products prod)
    {
        int res = 0;
        db.products.Add(prod);
        res = db.SaveChanges();
        return res;

    }

    public int DeleteProduct(int id)
    {
        int res = 0;
        var p = db.products.Where(x => x.ProductId == id).SingleOrDefault();
        if (p != null)
        {
            db.products.Remove(p);
            res = db.SaveChanges();
        }
        return res;
    }

    public IEnumerable<Products> GetAllProducts()
    {
        var res = (from p in db.products
                   join c in db.categories on p.CategoryId equals c.CategoryId
                   select new Products
                   {
                       ProductId = p.ProductId,
                       ProductName = p.ProductName,
                       Description = p.Description,
                       Pricepermonth = p.Pricepermonth,
                       Stockquantity = p.Stockquantity,
                       Imageurl = p.Imageurl,
                       VendorId = p.VendorId,
                       CategoryId = p.CategoryId,
                       CategoryName = c.CategoryName,



                   }).ToList();
        return res;
    }

    public Products GetProductById(int id)
    {
        var res = (from p in db.products
                   join c in db.categories on p.CategoryId equals c.CategoryId
                   where p.ProductId == id
                   select new Products
                   {
                       ProductId = p.ProductId,
                       ProductName = p.ProductName,
                       Description = p.Description,
                       Pricepermonth = p.Pricepermonth,
                       Stockquantity = p.Stockquantity,
                       Imageurl = p.Imageurl,
                       VendorId = p.VendorId,
                       CategoryId = p.CategoryId,
                       CategoryName = c.CategoryName



                   }).FirstOrDefault();
        return res;
    }

    public Products GetProductByName(string name)
    {
        var res = (from p in db.products
                   join c in db.categories on p.CategoryId equals c.CategoryId
                   where p.ProductName == name
                   select new Products
                   {
                       ProductId = p.ProductId,
                       ProductName = p.ProductName,
                       Description = p.Description,
                       Pricepermonth = p.Pricepermonth,
                       Stockquantity = p.Stockquantity,
                       Imageurl = p.Imageurl,
                       VendorId = p.VendorId,
                       CategoryId = p.CategoryId,
                       CategoryName = c.CategoryName



                   }).FirstOrDefault();
        return res;
    }

    public int UpdateProduct(Products prod)
    {
        int res = 0;
        var p = db.products.Where(x => x.ProductId == prod.ProductId).SingleOrDefault();

        if (p != null)
        {
            p.ProductName = prod.ProductName;
            p.Description = prod.Description;
            p.CategoryId = prod.CategoryId;
            p.Stockquantity = prod.Stockquantity;
            p.Imageurl = prod.Imageurl;
            p.Pricepermonth = prod.Pricepermonth;


        }
        return res;
    }
}


