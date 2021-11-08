using System;
using System.Collections.Generic;
using CoffeeMachine.Exceptions;
using CoffeeMachine.Ingredients;
using CoffeeMachine.Output;
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
        private const string Yes = "y";
        private const string No = "n";
        private IOutput _output = new CustomerOutput();
        private IUserInput _userInput;
        private List<string> _validDrinkCodes = new List<string>() {Coffee, Tea, Chocolate, OrangeJuice};

        public InputProcessor(IUserInput userInput)
        {
            _userInput = userInput;
        }

        public bool StillCollectingInput(string message)
        {
            _output = new CustomerOutput();
            _output.DisplayMessage(message);
            string response = _userInput.GetUserDecision();

            while (response != Yes && response != No)
            {
                _output.DisplayMessage(OutputMessages.InvalidInput);
                _output.DisplayMessage(OutputMessages.PleaseTryAgain);
                response = _userInput.GetUserDecision();
            }
            return response == Yes;
        }
        public Order AddInputToOrder(string input, Order order)
        {
            string inputCode = input[0].ToString().ToUpper();
            
            bool isDrink = _validDrinkCodes.Contains(inputCode);
            bool isMessage = inputCode == Message;

            if (isDrink)
            {
                IDrink drink = ProcessInput(input);
                _output.DisplayMessage(OutputMessages.SuccessfullyAdded);
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

            string drinkCode = input[0].ToString().ToUpper();
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