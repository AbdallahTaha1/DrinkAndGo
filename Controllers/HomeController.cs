using DrinkAndGo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DrinkAndGo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}