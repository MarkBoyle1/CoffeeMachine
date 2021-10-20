using System.Text;

namespace CoffeeMachine.Drinks
{
    public class Chocolate : IDrink
    {
        private string _drinkType;
        private string _sugarAmount;

        public Chocolate(string sugarAmount)
        {
            _drinkType = "Chocolate";
            _sugarAmount = sugarAmount;
        }

        public string GetDrinkType()
        {
            return _drinkType;
        }
        
        public string GetSugarAmount()
        {
            return _sugarAmount;
        }
    }
}