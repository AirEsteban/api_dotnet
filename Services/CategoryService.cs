using System.Linq.Expressions;
using webapi;
using webapi.Models;
namespace Api_dotnet.Services
{
    public class CategoryService : ICategoryService
    {
        private MyDbContext _context;

        public CategoryService(MyDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return this._context.Categories;
        }

        public Category? GetCategory(Guid id)
        {
            return this._context.Categories.Find(id);
        }

        public void UpdateCategory(Category newCategory)
        {
            var actualCategory = this._context.Categories.Find(newCategory.CategoryId);

            if(null != actualCategory)
            {
                actualCategory.Description = newCategory.Description;
                actualCategory.Weight = newCategory.Weight;
                actualCategory.Name = newCategory.Name;
            }
        }
    }

    public interface ICategoryService
    {
        public IEnumerable<Category> GetAllCategories();

        public Category? GetCategory(Guid id);

        public void UpdateCategory(Category newCategory);

    }
}
