using System;

namespace CoffeeMachine
{
    public class CoffeeMachineEngine
    {
        private InputProcessor _inputProcessor = new InputProcessor();
        public string CreateOrder(string input)
        {
            IDrink drink = _inputProcessor.ProcessInput(input);
            Order order = new Order();
            order = order.AddDrinkToOrder(drink);
            string message = order.BuildMessage();
            return message;
        }
    }
}