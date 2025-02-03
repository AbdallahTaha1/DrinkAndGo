using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.Models;
using DrinkAndGo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DrinkAndGo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;

        public HomeController(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public IActionResult Index()
        {
            var HVM = new HomeViewModel()
            {
                PreferedDrinks = _drinkRepository.PreferredDrinks
            };
            return View(HVM);
        }
    }
}