using System;
using System.Collections.Generic;
using System.Text;
using CoffeeMachine.Ingredients;
using Enum = System.Enum;

namespace CoffeeMachine.Drinks
{
    public class Chocolate : IDrink
    {
        private string _drinkType;
        private string _sugarAmount;
        private double _price;
        private DrinkTemperature _drinkTemperature;
        private List<IIngredient> _ingredients;


        public Chocolate(string sugarAmount, DrinkTemperature drinkTemperature)
        {
            _drinkType = "Chocolate";
            _price = 0.5;
            _sugarAmount = sugarAmount;
            _drinkTemperature = drinkTemperature;
            _ingredients = new List<IIngredient>()
            {
                new ChocolateFlakes(),
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