using System.Collections.Generic;
using System.Globalization;
using CoffeeMachine.Ingredients;

namespace CoffeeMachine.Drinks
{
    public class OrangeJuice : IDrink
    {
        private string _drinkType;
        private double _price;
        private List<IIngredient> _ingredients;
        
        public OrangeJuice()
        {
            _drinkType = "Orange Juice";
            _price = 0.6;
            _ingredients = new List<IIngredient>()
            {
                new Oranges()
            };

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
        
        public List<IIngredient> GetIngredientList()
        {
            return _ingredients;
        }
    }
}