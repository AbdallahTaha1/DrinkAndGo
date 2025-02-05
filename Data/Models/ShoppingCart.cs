using Microsoft.EntityFrameworkCore;

namespace DrinkAndGo.Data.Models
{
    public class ShoppingCart
    {
        private readonly DrinkAndGoContext _context;

        public ShoppingCart(DrinkAndGoContext context)
        {
            _context = context;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<DrinkAndGoContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Drink drink, int amount)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
                s => s.Drink.DrinkId == drink.DrinkId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Drink = drink,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount = amount++;
            }
            _context.SaveChanges();
        }
        public int RemoveFromCart(Drink drink)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
                s => s.Drink.DrinkId == drink.DrinkId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();

            return localAmount;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                                                 .Include(c => c.Drink)
                                                 .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _context
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(cartItems);

            _context.SaveChanges();
        }
        public decimal GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Drink.Price * c.Amount).Sum();
            return total;
        }
    }
}
