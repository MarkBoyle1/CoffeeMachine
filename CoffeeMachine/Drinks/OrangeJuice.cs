using System.Globalization;

namespace CoffeeMachine.Drinks
{
    public class OrangeJuice : IDrink
    {
        private string _drinkType;
        private double _price;


        public OrangeJuice()
        {
            _drinkType = "Orange Juice";
            _price = 0.6;

        }
        
        public string GetDrinkType()
        {
            return _drinkType;
        }
        
        public string GetSugarAmount()
        {
            return null;
        }
        
        public double GetPrice()
        {
            return _price;
        }
        
        public DrinkTemperature GetDrinkTemperature()
        {
            return DrinkTemperature.normal;
        }
    }
}