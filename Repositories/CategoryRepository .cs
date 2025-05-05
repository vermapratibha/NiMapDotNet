using Rentify.Data;
using Rentify.Models;

namespace Rentify.Repositories
{
    public class CategoryRepository : ICategoryRepository

    {
        private readonly ApplicationDbContext db;

        public CategoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCategory(Categories cat)
        {
            int res = 0;
            db.categories.Add(cat);
            res = db.SaveChanges();
            return res;

        }

        public int DeleteCategory(int id)
        {
            int res = 0;
            var c = db.categories.Where(x => x.CategoryId == id).SingleOrDefault();
            if (c != null)
            {
                db.categories.Remove(c);
                res = db.SaveChanges();
            }
            return res;

        }

        public IEnumerable<Categories> GetCategories()
        {
            return db.categories.ToList();

        }

        public Categories GetCategoryById(int id)
        {

            return db.categories.Where(x => x.CategoryId == id).SingleOrDefault();

        }

        public int UpdateCategory(Categories cat)
        {
            int res = 0;
            var c = db.categories.Where(x => x.CategoryId == cat.CategoryId).SingleOrDefault();
            if (c != null)
            {
                c.CategoryName = cat.CategoryName;
                res = db.SaveChanges();
            }
            return res;
        }
    }

}
    

