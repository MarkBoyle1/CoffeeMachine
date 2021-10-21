using System.Text;

namespace CoffeeMachine.Drinks
{
    public class Coffee : IDrink
    {
        private string _drinkType;
        private string _sugarAmount;
        private double _price;

        public Coffee(string sugarAmount)
        {
            _drinkType = "Coffee";
            _price = 0.6;
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
        
        public double GetPrice()
        {
            return _price;
        }
    }
}