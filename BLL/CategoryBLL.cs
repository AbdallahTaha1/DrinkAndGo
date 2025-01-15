using DrinkAndGo.Models;

namespace DrinkAndGo.BLL
{
    public class CategoryBLL : ICategoryRepository
    {
        private readonly DrinkAndGoContext _context;

        public CategoryBLL(DrinkAndGoContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.Categories;
    }
}
