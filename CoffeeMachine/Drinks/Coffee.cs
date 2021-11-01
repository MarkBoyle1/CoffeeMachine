using System.Collections.Generic;
using System.Text;
using CoffeeMachine.Ingredients;
using Enum = System.Enum;

namespace CoffeeMachine.Drinks
{
    public class Coffee : IDrink
    {
        private string _drinkType;
        private string _sugarAmount;
        private double _price;
        private DrinkTemperature _drinkTemperature;
        private List<IIngredient> _ingredients;



        public Coffee(string sugarAmount, DrinkTemperature drinkTemperature)
        {
            _drinkType = "Coffee";
            _price = 0.6;
            _sugarAmount = sugarAmount;
            _drinkTemperature = drinkTemperature;
            _ingredients = new List<IIngredient>()
            {
                new CoffeeBeans(),
                new Water(),
                new Milk()
            };

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
        
        public List<IIngredient> GetIngredientList()
        {
            return _ingredients;
        }
    }
}