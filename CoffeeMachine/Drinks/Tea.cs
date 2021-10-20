using System.Text;

namespace CoffeeMachine.Drinks
{
    public class Tea : IDrink
    {
        private string _drinkType;
        private string _sugarAmount;

        public Tea(string sugarAmount)
        {
            _drinkType = "Tea";
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