namespace DrinkAndGo.Models
{
    public class DrinkListVeiwModel
    {
        public string CurrentCategory {  get; set; } 
        public IEnumerable<Drink> Drinks{ get; set; }
    }
}
