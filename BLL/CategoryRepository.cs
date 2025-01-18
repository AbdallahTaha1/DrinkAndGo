using DrinkAndGo.Models;

namespace DrinkAndGo.BLL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DrinkAndGoContext _context;

        public CategoryRepository(DrinkAndGoContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.Categories;
    }
}
