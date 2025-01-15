
using Microsoft.EntityFrameworkCore;

namespace DrinkAndGo.Models
{
    public class DrinkAndGoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=DrinkAndGo;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Drink> Drinks { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}
    }
}
