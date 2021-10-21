using System.Text;

namespace CoffeeMachine.Drinks
{
    public class Coffee : IDrink
    {
        private string _drinkType;
        private string _sugarAmount;
        private double _price;
        private DrinkTemperature _drinkTemperature;

        public Coffee(string sugarAmount, DrinkTemperature drinkTemperature)
        {
            _drinkType = "Coffee";
            _price = 0.6;
            _sugarAmount = sugarAmount;
            _drinkTemperature = drinkTemperature;
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
        
        public DrinkTemperature GetDrinkTemperature()
        {
            return _drinkTemperature;
        }
    }
}