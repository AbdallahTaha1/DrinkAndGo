using DrinkAndGo.BLL;
using DrinkAndGo.Models;
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

        public IActionResult Index()
        {
            DrinkListVeiwModel model = new DrinkListVeiwModel();
            IEnumerable<Drink> drinks = _drinkRepository.Drinks;
            model.Drinks = drinks;
            model.CurrentCategory = "All Category"; 
            return View(model);
        }
    }
}
