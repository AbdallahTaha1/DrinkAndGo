using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.Controllers
{
    public class DrinkController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDrinkRepository _drinkRepository;

        public DrinkController(ICategoryRepository categoryRepository, IDrinkRepository drinkRepository)
        {
            _categoryRepository = categoryRepository;
            _drinkRepository = drinkRepository;
        }

        public IActionResult List([FromQuery]string category)
        {
            ViewBag.Name = category;

            IEnumerable<Drink> drinks;
            DrinkListVeiwModel model = new DrinkListVeiwModel();

            if (String.IsNullOrEmpty(category))
            {
                drinks = _drinkRepository.Drinks;
                model.Drinks = drinks;
                model.CurrentCategory = "All Categories";
            }
            else
            {
                drinks = _drinkRepository.Drinks.Where(d => d.Category.CategoryName == category);
                model.Drinks = drinks;
                model.CurrentCategory = category;
            }
            return View(model);
        }
    }
}
