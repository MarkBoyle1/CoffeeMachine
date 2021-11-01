using System;

namespace CoffeeMachine.Ingredients
{
    public class ChocolateFlakes : IIngredient

    {
        public string name = "ChocolateFlakes";
        private int stockLevel = IngredientStock.stockLevels["ChocolateFlakes"];
        

        public bool isEmpty()
        {
            return stockLevel == 0;
        }

        public string GetIngredientName()
        {
            return name;
        }
    }
}