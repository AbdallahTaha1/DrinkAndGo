using DrinkAndGo.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinkAndGo.BLL
{
    public class DrinkBLL : IDrinkRepository
    {
        DrinkAndGoContext context = new DrinkAndGoContext();
        public IEnumerable<Drink> Drinks => context.Drinks.Include(c=>c.Category);

        public IEnumerable<Drink> PreferredDrinks => throw new NotImplementedException();

        public Drink GetDrinkById(int drinkId)
        {
            throw new NotImplementedException();
        }
    }
}
