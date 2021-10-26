using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CoffeeMachine.Exceptions;
using CoffeeMachine.Output;

namespace CoffeeMachine
{
    public class CoffeeMachineEngine
    {
        private InputProcessor _inputProcessor;
        private MessageBuilder _messageBuilder;
        private IOutput _output;
        private IUserInput _userInput;
        private List<char> _validDrinkCodes;
        private ReportBuilder _reportBuilder;

        public CoffeeMachineEngine(IUserInput userInput)
        {
            _userInput = userInput;
            _output = new CustomerOutput();
            _inputProcessor = new InputProcessor();
            _messageBuilder = new MessageBuilder();
            _reportBuilder = new ReportBuilder();
            _validDrinkCodes = new List<char>() {'C', 'T', 'H', 'O'};
        }

        public void RunProgram()
        {
            _output.DisplayMessage(OutputMessages.Welcome);
            List<Order> allOrders = CollectAllOrders();
            
            Report report = _reportBuilder.CreateReport(allOrders);
            DisplayReport(report);
        }
        
        public List<Order> CollectAllOrders()
        {
            List<Order> allOrders = new List<Order>();
            
            while (StillPlacingOrders())
            {
                Order order = CollectOneOrder();
                
                allOrders.Add(order);
            }

            return allOrders;
        }

        public Order CollectOneOrder()
        {
            List<Item> input = CollectInput();
            
            double moneyInserted = CollectMoney();
            
            Order order = new Order(input);

            while (moneyInserted < order.TotalPrice)
            {
                RejectOrder(order, moneyInserted);
                double additionalMoney = CollectMoney();
                moneyInserted += additionalMoney;
            }
            
            SendOrderToDrinkMaker(order);
            return order;
        }
        
        private List<Item> CollectInput()
        {
            List<Item> order = new List<Item>();

            while (StillCollectingInput())
            {
                string userResponse = _userInput.GetUserResponse();

                if (_validDrinkCodes.Contains(userResponse[0]))
                {
                    IDrink drink = _inputProcessor.ProcessInput(userResponse);
                    Item item = new Item(drink);
                    order.Add(item);
                }
                else if (userResponse[0] == 'M')
                {
                    Item item = new Item(userResponse);
                    order.Add(item);
                }
                else
                {
                    _output.DisplayMessage(OutputMessages.InvalidInput);
                }
            }

            return order;
        }

        private void SendOrderToDrinkMaker(Order order)
        {
            _output = new DrinkMakerOutput();
            string message = _messageBuilder.BuildOrderMessage(order);
            _output.DisplayMessage(message);
        }

        private void RejectOrder(Order order, double moneyInserted)
        {
            _output = new CustomerOutput();
            string message = _messageBuilder.BuildNotEnoughMoneyMessage(moneyInserted, order.TotalPrice);
            _output.DisplayMessage(message);
        }

        private bool StillPlacingOrders()
        {
            _output = new CustomerOutput();
            _output.DisplayMessage(OutputMessages.AddMoreOrders);
            return _userInput.GetUserDecision();
        }

        private double CollectMoney()
        {
            _output.DisplayMessage(OutputMessages.InsertMoney);
            string moneyInserted = _userInput.GetUserResponse();
            return Convert.ToDouble(moneyInserted);
        }

        private bool StillCollectingInput()
        {
            _output = new CustomerOutput();
            _output.DisplayMessage(OutputMessages.AddMoreDrinks);
            return _userInput.GetUserDecision();
        }

        private void DisplayReport(Report report)
        {
            _output.DisplayMessage(OutputMessages.Report);
            foreach (var drink in report._results)
            {
                string data = (drink.Key + ": " + Math.Round(drink.Value,2));
                _output.DisplayMessage(data);
            }
        }
    }
}