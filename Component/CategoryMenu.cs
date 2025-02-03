using DrinkAndGo.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.Component
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(categories);
        }
    }
}
