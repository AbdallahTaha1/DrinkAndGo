namespace DrinkAndGo.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Drink Drink { get; set; }
        public int amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
