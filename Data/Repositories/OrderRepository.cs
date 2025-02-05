using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.Data.Models;

namespace DrinkAndGo.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DrinkAndGoContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(DrinkAndGoContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _context.Orders.Add(order);

            var shopingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var item in shopingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    DrinkId = item.Drink.DrinkId,
                    OrderId = order.OrderId,
                    Price = item.Drink.Price
                };
                _context.Add(orderDetail);
                order.OrderLines.Add(orderDetail);
            }
            _context.SaveChanges();
        }
    }
}
