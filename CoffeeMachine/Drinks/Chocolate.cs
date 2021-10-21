using System.Text;

namespace CoffeeMachine.Drinks
{
    public class Chocolate : IDrink
    {
        private string _drinkType;
        private string _sugarAmount;
        private double _price;

        public Chocolate(string sugarAmount)
        {
            _drinkType = "Chocolate";
            _price = 0.5;
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