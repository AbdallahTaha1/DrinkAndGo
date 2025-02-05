using DrinkAndGo.Data.Models;
using DrinkAndGo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.Component
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        //Automatically used each time our component Invoked
        public IViewComponentResult Invoke() 
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartVM = new ShoppingCartViewModel() 
            { 
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartVM);
        }

    }
}
