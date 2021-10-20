using System;
using System.Linq;
using CoffeeMachine.Output;

namespace CoffeeMachine
{
    public class CoffeeMachineEngine
    {
        private InputProcessor _inputProcessor;
        private MessageBuilder _messageBuilder;
        private IOutput _output;

        public CoffeeMachineEngine()
        {
            _inputProcessor = new InputProcessor();
            _messageBuilder = new MessageBuilder();
        }
        
        public string CreateMessage(string input)
        {
            string message;
            
            if (input.First() == 'M')
            {
                _output = new CustomerOutput();
                message = CreateMessageForCustomer(input);
            }
            else
            {
                _output = new DrinkMakerOutput();
                message = CreateOrder(input);
            }
            
            _output.DisplayMessage(message);

            return message;
        }
        
        public string CreateOrder(string input)
        {
            IDrink drink = _inputProcessor.ProcessInput(input);

            Order order = new Order(drink);

            string finalMessage = _messageBuilder.BuildOrderMessage(order.DrinkList);
            
            return finalMessage;
        }
        
        private string CreateMessageForCustomer(string input)
        {
            string message = input.Substring(2);
            
            return message;
        }
    }
}