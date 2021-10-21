using System;
using System.Collections.Generic;
using CoffeeMachine.Drinks;

namespace CoffeeMachine
{
    public class InputProcessor
    {
        public IDrink ProcessInput(string input)
        {
            string[] inputArray = input.Split(':', StringSplitOptions.RemoveEmptyEntries);

            string drinkCode = input[0].ToString();
            string sugarAmount = inputArray.Length > 1 ? inputArray[1] : "0";
            DrinkTemperature drinkTemperature = inputArray[0].Contains('h') 
                    ? DrinkTemperature.extra_hot
                    : DrinkTemperature.normal;
            
            IDrink drink = null;

            switch (drinkCode)
            {
                case "C" : 
                    drink = new Coffee(sugarAmount, drinkTemperature);
                    break;
                case "T" : 
                    drink = new Tea(sugarAmount, drinkTemperature);
                    break;
                case "H" : 
                    drink = new Chocolate(sugarAmount, drinkTemperature);
                    break;
                case "O" : 
                    drink = new OrangeJuice();
                    break;
            }

            return drink;
        }
    }
}