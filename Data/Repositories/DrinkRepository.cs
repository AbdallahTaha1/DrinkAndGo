using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinkAndGo.Data.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly DrinkAndGoContext _context;

        public DrinkRepository(DrinkAndGoContext context)
        {
            _context = context;
        }

        public IEnumerable<Drink> Drinks => _context.Drinks.Include(c => c.Category);

        public IEnumerable<Drink> PreferredDrinks => _context.Drinks.Where(d => d.IsPreferredDrink).Include(c => c.Category);

        public Drink? GetDrinkById(int drinkId) => _context.Drinks.FirstOrDefault(d => d.DrinkId == drinkId);

    }
}
