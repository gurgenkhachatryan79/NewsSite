using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models.Categories.CategoryServices
{
   public interface ICategoryService
    {
        IAsyncEnumerable<Category> GetCategoris();
        Task<Category> GetCategoryById(int id);
        Task AddCategory(CategoryDto categorydto);
        Task UpdateCategory(CategoryDto categorydto, int id);
        Task DeleteCategory(int id);
    }
}
