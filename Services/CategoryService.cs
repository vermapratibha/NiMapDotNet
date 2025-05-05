using Rentify.Models;
using Rentify.Repositories;

namespace Rentify.Services
{
    public class CategoryService : ICategoryService

    {
        private readonly ICategoryRepository repo;

        public CategoryService(ICategoryRepository repo)
        {
            this.repo = repo;

        }

        public int AddCategory(Categories cat)
        {
            return repo.AddCategory(cat);

        }

        public int DeleteCategory(int id)
        {
            return repo.DeleteCategory(id);

        }

        public IEnumerable<Categories> GetCategories()
        {
            return repo.GetCategories();

        }

        public Categories GetCategoryById(int id)
        {
            return repo.GetCategoryById(id);

        }

        public int UpdateCategory(Categories cat)
        {
            return repo.UpdateCategory(cat);

        }
    }
}
