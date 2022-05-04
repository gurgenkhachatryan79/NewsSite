using Microsoft.EntityFrameworkCore;
using NewsSite.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models.Categories.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly NewsDbContext _context;
        public CategoryService(NewsDbContext context)
        {
            _context = context;
        }

        public async Task AddCategory(CategoryDto categorydto)
        {
            Category category = new Category()
            {
                Id = categorydto.Id,
                Name = categorydto.Name,
                News = categorydto.News
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            Validation.ValidationId(id);
            Category category =await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                throw new NullReferenceException();
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async IAsyncEnumerable<Category> GetCategoris()
        {
            var categories = _context.Categories;
            if (categories == null)
            {
                throw new NullReferenceException();
            }
            foreach (var item in categories)
            {
                yield return item;
            }
        }

        public async Task<Category> GetCategoryById(int id)
        {
            Validation.ValidationId(id);
            Category category= await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                throw new NullReferenceException();
            }
            return category;
        }

        public async Task UpdateCategory(CategoryDto categorydto, int id)
        {
            Validation.ValidationId(id);
            Category category=new Category()
            {
                Id=categorydto.Id,
                Name=categorydto.Name,
                News=categorydto.News
            };
            if (category == null)
            {
                throw new NullReferenceException();
            }
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
