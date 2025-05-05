using Rentify.Models;

namespace Rentify.Services
{
    public interface ICategoryService
    {
        IEnumerable<Categories> GetCategories();

        Categories GetCategoryById(int id);

        int AddCategory(Categories cat);

        int UpdateCategory(Categories cat);

        int DeleteCategory(int id);

    }
}
