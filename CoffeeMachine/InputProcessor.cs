using System;
using System.Collections.Generic;
using CoffeeMachine.Drinks;
using CoffeeMachine.Exceptions;

namespace CoffeeMachine
{
    public class InputProcessor
    {
        public Item CreateItem(string input)
        {
            List<char> _validDrinkCodes = new List<char>() {'C', 'T', 'H', 'O'};
            
            if (_validDrinkCodes.Contains(input[0]))
            {
                IDrink drink = ProcessInput(input);
                return new Item(drink);
            }
            if (input[0] == 'M')
            {
                return new Item(input);
            }
            
            throw new InvalidInputException(input);
        }
        public IDrink ProcessInput(string input)
        {
            string[] inputArray = input.Split(':', StringSplitOptions.RemoveEmptyEntries);

            string drinkCode = input[0].ToString();
            string sugarAmount = inputArray.Length > 1 ? inputArray[1] : "0";
            DrinkTemperature drinkTemperature = inputArray[0].Contains('h') 
                    ? DrinkTemperature.extra_hot
                    : DrinkTemperature.normal;

            switch (drinkCode)
            {
                case "C" : 
                    return new Coffee(sugarAmount, drinkTemperature);
                case "T" : 
                    return new Tea(sugarAmount, drinkTemperature);
                case "H" : 
                    return new Chocolate(sugarAmount, drinkTemperature);
                case "O" : 
                    return new OrangeJuice();
                default:
                    throw new InvalidInputException(drinkCode);
            }
        }
    }
}