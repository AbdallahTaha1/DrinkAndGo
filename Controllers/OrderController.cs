using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;

        public OrderController(ShoppingCart shoppingCart, IOrderRepository orderRepository)
        {
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
        }
        [Authorize]
        [HttpGet]
        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult CheckOut(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
                ModelState.AddModelError("", "Your cart is empty, add some drinks first");
            if(ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
               _shoppingCart.ClearCart();
                return RedirectToAction(nameof(CheckoutComplete));
            }
            return View(order);
        }
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks For your order";
            return View();
        }

    }
}
