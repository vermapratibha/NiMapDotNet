using Rentify.Models;

namespace Rentify.Repositories
{
    public interface ICategoryRepository
    {

        IEnumerable<Categories> GetCategories();

        Categories GetCategoryById(int id);

        int AddCategory(Categories cat);

        int UpdateCategory(Categories cat);

        int DeleteCategory(int id);


    }
}
