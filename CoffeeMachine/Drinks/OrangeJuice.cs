using System.Globalization;

namespace CoffeeMachine.Drinks
{
    public class OrangeJuice : IDrink
    {
        private string _drinkType;
        private double _price;
        private int _quantity;


        public OrangeJuice(int quantity)
        {
            _drinkType = "Orange Juice";
            _price = 0.6;
            _quantity = quantity;

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
        
        public int GetQuantity()
        {
            return _quantity;
        }
    }
}