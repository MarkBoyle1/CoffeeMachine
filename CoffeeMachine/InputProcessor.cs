using System;
using System.Collections.Generic;
using CoffeeMachine.Exceptions;
using CoffeeMachine.Ingredients;
using Chocolate = CoffeeMachine.Drinks.Chocolate;
using Coffee = CoffeeMachine.Drinks.Coffee;
using OrangeJuice = CoffeeMachine.Drinks.OrangeJuice;
using Tea = CoffeeMachine.Drinks.Tea;

namespace CoffeeMachine
{
    public class InputProcessor
    {
        public Order AddInputToOrder(string input, Order order)
        {
            List<char> _validDrinkCodes = new List<char>() {'C', 'T', 'H', 'O'};
            bool isDrink = _validDrinkCodes.Contains(input[0]);
            bool isMessage = input[0] == 'M';

            if (isDrink)
            {
                IDrink drink = ProcessInput(input);
                return new Order(order, drink);
            }
            if (isMessage)
            {
                Message message = new Message(input);
                return new Order(order, message);
            }
            
            throw new InvalidInputException(input);
        }

        private IDrink ProcessInput(string input)
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