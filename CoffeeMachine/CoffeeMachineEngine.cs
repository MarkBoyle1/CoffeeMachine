using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CoffeeMachine.Exceptions;
using CoffeeMachine.Ingredients;
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
        private IEmailNotifier _emailNotifier;
        private IngredientQuantityChecker _ingredientQuantityChecker;

        public CoffeeMachineEngine(IUserInput userInput)
        {
            _userInput = userInput;
            _output = new CustomerOutput();
            _inputProcessor = new InputProcessor();
            _messageBuilder = new MessageBuilder();
            _reportBuilder = new ReportBuilder();
            _emailNotifier = new EmailNotifier();
            _ingredientQuantityChecker = new IngredientQuantityChecker();
        }

        public Report RunProgram()
        {
            _output.DisplayMessage(OutputMessages.Welcome);
            List<Order> allOrders = CollectAllOrders();
            
            Report report = _reportBuilder.CreateReport(allOrders);
            DisplayReport(report);
            
            return report;
        }
        
        private List<Order> CollectAllOrders()
        {
            List<Order> allOrders = new List<Order>();
            
            while (StillPlacingOrders())
            {
                Order order = CollectOneOrder();
                
                allOrders.Add(order);
            }

            return allOrders;
        }
        
        private bool StillPlacingOrders()
        {
            _output = new CustomerOutput();
            _output.DisplayMessage(OutputMessages.AddMoreOrders);
            return _userInput.GetUserDecision();
        }

        private Order CollectOneOrder()
        {
            Order order = CollectInput();

            List<IIngredient> emptyIngredients = _ingredientQuantityChecker.CheckForEmptyIngredients(order);

            if (emptyIngredients.Count > 0)
            {
                _emailNotifier.notifyMissingIngredients(emptyIngredients);
                return new Order(order);
            }
            
            double orderPrice = GetOrderPrice(order);
            double moneyInserted = CollectMoney();
            
            while (moneyInserted < orderPrice)
            {
                RejectOrder(orderPrice, moneyInserted);
                double additionalMoney = CollectMoney();
                moneyInserted += additionalMoney;
            }
            
            SendOrderToDrinkMaker(order);
            
            return order;
        }
        
        private double GetOrderPrice(Order order)
        {
            double totalPrice = 0;

            foreach (var drink in order.DrinkList)
            {
                totalPrice += drink.GetPrice();
            }

            return totalPrice;
        }
        
        private Order CollectInput()
        {
            Order order = new Order();

            while (StillCollectingInput())
            {
                string userResponse = _userInput.GetUserResponse();

                try
                {
                    order = _inputProcessor.AddInputToOrder(userResponse, order);
                }
                catch (InvalidInputException)
                {
                    _output.DisplayMessage(OutputMessages.InvalidInput);
                }
            }

            return order;
        }
        
        private bool StillCollectingInput()
        {
            _output = new CustomerOutput();
            _output.DisplayMessage(OutputMessages.AddMoreDrinks);
            return _userInput.GetUserDecision();
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

        private double CollectMoney()
        {
            _output.DisplayMessage(OutputMessages.InsertMoney);
            string moneyInserted = _userInput.GetUserResponse();
            return Convert.ToDouble(moneyInserted);
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