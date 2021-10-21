using System.Text;

namespace CoffeeMachine.Drinks
{
    public class Tea : IDrink
    {
        private string _drinkType;
        private string _sugarAmount;
        private double _price;
        private DrinkTemperature _drinkTemperature;

        public Tea(string sugarAmount, DrinkTemperature drinkTemperature)
        {
            _drinkType = "Tea";
            _price = 0.4;
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