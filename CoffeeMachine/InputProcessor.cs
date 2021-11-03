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
        private const string Coffee = "C";
        private const string Tea = "T";
        private const string Chocolate = "H";
        private const string OrangeJuice = "O";
        private const string ExtraHot = "h";
        private const string Message = "M";

        public Order AddInputToOrder(string input, Order order)
        {
            List<string> _validDrinkCodes = new List<string>() {Coffee, Tea, Chocolate, OrangeJuice};
            
            bool isDrink = _validDrinkCodes.Contains(input[0].ToString());
            bool isMessage = input[0].ToString() == Message;

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
            DrinkTemperature drinkTemperature = inputArray[0].Contains(ExtraHot) 
                    ? DrinkTemperature.ExtraHot
                    : DrinkTemperature.Normal;

            switch (drinkCode)
            {
                case Coffee : 
                    return new Coffee(sugarAmount, drinkTemperature);
                case Tea : 
                    return new Tea(sugarAmount, drinkTemperature);
                case Chocolate : 
                    return new Chocolate(sugarAmount, drinkTemperature);
                case OrangeJuice : 
                    return new OrangeJuice();
                default:
                    throw new InvalidInputException(drinkCode);
            }
        }
    }
}