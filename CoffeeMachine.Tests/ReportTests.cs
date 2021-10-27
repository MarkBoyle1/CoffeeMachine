using System.Collections.Generic;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class ReportTests
    {
        
        private List<string> listOfResponses;
        private List<string> listOfDecisions;
        private ReportBuilder _reportBuilder;
        private CoffeeMachineEngine _coffeeMachineEngine;
        private InputProcessor _inputProcessor;

        public ReportTests()
        {
            listOfResponses = new List<string>() {"T::", "0.4"};
            listOfDecisions = new List<string>() {"y", "y", "n", "n"};
            _coffeeMachineEngine = new CoffeeMachineEngine(new TestUserInput(listOfResponses, listOfDecisions));
            _reportBuilder = new ReportBuilder();
            _inputProcessor = new InputProcessor();
        }
        
        [Fact]
        public void given_orderContainsThreeDrinks_when_CreateReport_then_return_reportWithDictionaryOfSales()
        {
            string[] input = new[] {"Ch::", "Ch::", "C::", "H:1:0"};
            Order order = CreateOrder(input);
        
            List<Order> orders = new List<Order>() {order};
        
            Report report = _reportBuilder.CreateReport(orders);
        
            Dictionary<string, double> results = new Dictionary<string, double>()
            {
                {"Coffee", 3},
                {"Chocolate", 1},
                {"Total Revenue", 2.3}
            };
        
            Assert.Equal(results, report._results);
        }
        
        [Fact]
        public void given_twoOrderContainsThreeDrinksEach_when_CreateReport_then_return_reportWithDictionaryOfSales()
        {
            string[] input1 = new[] {"Ch::", "Ch::", "C::", "H:1:0"};
            string[] input2 = new[] {"Ch::", "T::", "O::", "H:1:0"};

            Order order1 = CreateOrder(input1);
            Order order2 = CreateOrder(input2);
            
            List<Order> orders = new List<Order>() {order1, order2};
        
            Report report = _reportBuilder.CreateReport(orders);
        
            Dictionary<string, double> results = new Dictionary<string, double>()
            {
                {"Coffee", 4},
                {"Chocolate", 2},
                {"Tea", 1},
                {"Orange Juice", 1},
                {"Total Revenue", 4.4}
            };
        
            Assert.Equal(results, report._results);
        }

        public Order CreateOrder(string[] input)
        {
            List<Item> messages = new List<Item>();
            List<char> _validDrinkCodes = new List<char>() {'C', 'T', 'H', 'O'};

            foreach (var element in input)
            {
                if (_validDrinkCodes.Contains(element[0]))
                {
                    IDrink drink = _inputProcessor.ProcessInput(element);
                    Item item = new Item(drink);
                    messages.Add(item);
                }
                else if (element[0] == 'M')
                {
                    Item item = new Item(element);
                    messages.Add(item);
                }
            }
            
            double orderPrice = GetOrderPrice(messages);
            
            Order order = new Order(messages, orderPrice);

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
    }
}