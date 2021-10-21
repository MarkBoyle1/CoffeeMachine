using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CoffeeMachine.Output;

namespace CoffeeMachine
{
    public class CoffeeMachineEngine
    {
        private InputProcessor _inputProcessor;
        private MessageBuilder _messageBuilder;
        private IOutput _output;
        private List<char> _validDrinkCodes;

        public CoffeeMachineEngine()
        {
            _inputProcessor = new InputProcessor();
            _messageBuilder = new MessageBuilder();
            _validDrinkCodes = new List<char>() {'C', 'T', 'H', 'O'};
        }
        
        public string CreateMessage(params string[] input)
        {
            string message = "";
            
            double number;
            double moneyInserted = double.TryParse(input.Last(), out number) ? Convert.ToDouble(input.Last()) : 0;
            
            if (input[0].First() == 'M')
            {
                _output = new CustomerOutput();
                message = CreateMessageForCustomer(input[0]);
                return message;
            }
            
            if(_validDrinkCodes.Contains(input[0].First()))
            {
                _output = new DrinkMakerOutput();
                Order order = CreateOrder(input);

                message = moneyInserted < order.TotalPrice
                    ? _messageBuilder.BuildNotEnoughMoneyMessage(moneyInserted, order.TotalPrice)
                    : _messageBuilder.BuildOrderMessage(order);
            
            _output.DisplayMessage(message);
            return message;
            }

            message = "Invalid Input.";
            _output.DisplayMessage(message);
            return message;
        }
        
        public Order CreateOrder(string[] input)
        {
            Order order = new Order();

            //Group exact drink orders together
            List<IGrouping<string, string>> groupedOrder = input.GroupBy(drinkCode => drinkCode).ToList();

            for (int i = 0; i <= groupedOrder.Count- 1; i++)
            {
                string drinkCode = groupedOrder[i].Key;
                int quantity = groupedOrder[i].Count();
                
                IDrink drink = _inputProcessor.ProcessInput(drinkCode, quantity);
                if (drink != null)
                {
                    order = new Order(order, drink);
                }
            }

            return order;
        }
        
        private string CreateMessageForCustomer(string input)
        {
            string message = input.Substring(2);
            
            return message;
        }
    }
}