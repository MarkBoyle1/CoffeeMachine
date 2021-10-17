using System;
using System.Collections.Generic;
using CoffeeMachine.Drinks;

namespace CoffeeMachine
{
    public class InputProcessor
    {
        private Dictionary<string, IDrink> drinks;
        private string _drink;
        private string _sugarAmount;

        public InputProcessor()
        {
            drinks = new Dictionary<string, IDrink>()
            {
                {"C", new Coffee()},
                {"T", new Tea()},
                {"H", new Chocolate()}
            };
        }
        
        public IDrink ProcessInput(string input)
        {
            string[] inputArray = SplitInput(input);

            string drinkCode = input[0].ToString();
            string sugarAmount = inputArray.Length > 1 ? inputArray[1] : "0";

            IDrink drink = drinks[drinkCode];
            drink = drink.AddSugar(sugarAmount);

            return drink;
        }

        private string[] SplitInput(string input)
        {
            return input.Split(':', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}