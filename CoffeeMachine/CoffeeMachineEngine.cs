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
        private ReportBuilder _reportBuilder;

        public CoffeeMachineEngine(IUserInput userInput)
        {
            _userInput = userInput;
            _output = new CustomerOutput();
            _inputProcessor = new InputProcessor();
            _messageBuilder = new MessageBuilder();
            _reportBuilder = new ReportBuilder();
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
            double orderPrice = GetOrderPrice(input);
            double moneyInserted = CollectMoney();
            
            while (moneyInserted < orderPrice)
            {
                RejectOrder(orderPrice, moneyInserted);
                double additionalMoney = CollectMoney();
                moneyInserted += additionalMoney;
            }
            
            Order order = new Order(input, orderPrice);
            SendOrderToDrinkMaker(order);
            
            return order;
        }
        
        private List<Item> CollectInput()
        {
            List<Item> order = new List<Item>();

            while (StillCollectingInput())
            {
                string userResponse = _userInput.GetUserResponse();

                try
                {
                    Item item = _inputProcessor.CreateItem(userResponse);
                    order.Add(item);
                }
                catch (InvalidInputException)
                {
                    _output.DisplayMessage(OutputMessages.InvalidInput);
                }
            }

            return order;
        }
        
        private double GetOrderPrice(List<Item> input)
        {
            double totalPrice = 0;

            foreach (var message in input)
            {
                totalPrice += message.Value;
            }

            return totalPrice;
        }

        private void SendOrderToDrinkMaker(Order order)
        {
            _output = new DrinkMakerOutput();
            string message = _messageBuilder.BuildOrderMessage(order);
            _output.DisplayMessage(message);
        }

        private void RejectOrder(double orderPrice, double moneyInserted)
        {
            _output = new CustomerOutput();
            string message = _messageBuilder.BuildNotEnoughMoneyMessage(moneyInserted, orderPrice);
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