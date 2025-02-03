using Microsoft.EntityFrameworkCore;

namespace DrinkAndGo.Data.Models
{
    public class DrinkAndGoContext : DbContext
    {
        public DrinkAndGoContext(DbContextOptions<DrinkAndGoContext> options) : base(options) { }

        public virtual DbSet<Drink> Drinks { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
