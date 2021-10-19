using System;

namespace CoffeeMachine
{
    public class CoffeeMachineEngine
    {
        private InputProcessor _inputProcessor;
        private MessageBuilder _messageBuilder;
        private Output _output;

        public CoffeeMachineEngine()
        {
            _inputProcessor = new InputProcessor();
            _messageBuilder = new MessageBuilder();
            _output = new Output();
        }
        public string CreateOrder(string input)
        {
            IDrink drink = _inputProcessor.ProcessInput(input);

            Order order = new Order();
            order.AddDrinkToOrder(drink);
            
            string finalMessage = _messageBuilder.BuildOrderMessage(order.DrinkList);
            _output.DisplayMessage(finalMessage);
            
            return finalMessage;
        }
    }
}