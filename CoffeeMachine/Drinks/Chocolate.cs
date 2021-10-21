using System.Text;

namespace CoffeeMachine.Drinks
{
    public class Chocolate : IDrink
    {
        private string _drinkType;
        private string _sugarAmount;
        private double _price;
        private DrinkTemperature _drinkTemperature;
        private int _quantity;


        public Chocolate(string sugarAmount, DrinkTemperature drinkTemperature, int quantity)
        {
            _drinkType = "Chocolate";
            _price = 0.5;
            _sugarAmount = sugarAmount;
            _drinkTemperature = drinkTemperature;
            _quantity = quantity;

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
        
        public int GetQuantity()
        {
            return _quantity;
        }
    }
}