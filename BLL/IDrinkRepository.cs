using DrinkAndGo.Models;

namespace DrinkAndGo.BLL
{
    public interface IDrinkRepository
    {
        IEnumerable<Drink> Drinks { get; }
        IEnumerable<Drink> PreferredDrinks { get;}
        Drink GetDrinkById(int drinkId);
    }
}
