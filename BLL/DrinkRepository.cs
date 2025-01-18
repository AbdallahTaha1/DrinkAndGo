using DrinkAndGo.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinkAndGo.BLL
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
