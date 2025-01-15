using DrinkAndGo.Models;

namespace DrinkAndGo.BLL
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}