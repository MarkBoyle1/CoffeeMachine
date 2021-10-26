using System;
using System.Collections.Generic;
using CoffeeMachine.Drinks;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class CoffeeMachineTests
    {
        private List<string> listOfResponses;
        private List<string> listOfDecisions;
        private ReportBuilder _reportBuilder;
        private CoffeeMachineEngine _coffeeMachineEngine;
        private MessageBuilder _messageBuilder;
        private InputProcessor _inputProcessor;

        public CoffeeMachineTests()
        {
            listOfResponses = new List<string>() {"T::"};
            listOfDecisions = new List<string>() {"y", "y", "y", "n", "n"};
            _coffeeMachineEngine = new CoffeeMachineEngine(new TestUserInput(listOfResponses, listOfDecisions));
            _messageBuilder = new MessageBuilder();
            _reportBuilder = new ReportBuilder();
            _inputProcessor = new InputProcessor();
        }
        
        [Fact]
        public void given_inputEqualsT_when_CreateMessage_then_returns_Make_1_Tea_with_no_sugar_and_no_stick()
        {
            string[] input = new[] {"T::"};
            Order order = CreateOrder(input);
            
            string expectedMessage = "Make 1 Tea with no sugar and no stick\n";
            string actualMessage = _messageBuilder.BuildOrderMessage(order);
            
            Assert.Equal(expectedMessage, actualMessage);
        }
        
        [Fact]
        public void given_inputEqualsT1_when_CreateMessage_then_returns_Make_1_Tea_with_1_sugar_and_a_stick()
        {
            string[] input = new[] {"T:1:"};
            Order order = CreateOrder(input);
            
            string expectedMessage = "Make 1 Tea with 1 sugar and a stick\n";
            string actualMessage = _messageBuilder.BuildOrderMessage(order);
            
            Assert.Equal(expectedMessage, actualMessage);
        }
        
        [Fact]
        public void given_inputEqualsC1_when_CreateMessage_then_returns_Make_1_Coffee_with_1_sugar_and_a_stick()
        {
            string[] input = new[] {"C:1:"};
            Order order = CreateOrder(input);
            
            string expectedMessage = "Make 1 Coffee with 1 sugar and a stick\n";
            string actualMessage = _messageBuilder.BuildOrderMessage(order);
            
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void given_inputEqualsC1andH_when_CreateMessage_then_returns_Make_1_Coffee_with_1_sugar_and_a_stick()
        {
            string[] input = new[] {"C:1:", "H::"};
            Order order = CreateOrder(input);
            
            string expectedMessage = "Make 1 Coffee with 1 sugar and a stick\n" +
                                     "Make 1 Chocolate with no sugar and no stick\n";
            string actualMessage = _messageBuilder.BuildOrderMessage(order);
            
            Assert.Equal(expectedMessage, actualMessage);
        }
        
        [Fact]
        public void given_inputEqualsO_when_CreateMessage_then_returns_Make_1_Orange_Juice()
        {
            string[] input = new[] {"O::"};
            Order order = CreateOrder(input);

            string expectedMessage = "Make 1 Orange Juice\n";
            string actualMessage = _messageBuilder.BuildOrderMessage(order);
            
            Assert.Equal(expectedMessage, actualMessage);
        }
        
        [Fact]
        public void given_inputEqualsCh_when_CreateMessage_then_returns_Make_1_Extra_Hot_Coffee_with_no_sugar_and_no_stick()
        {
            string[] input = new[] {"Ch::"};
            Order order = CreateOrder(input);

            string expectedMessage = "Make 1 extra hot Coffee with no sugar and no stick\n";
            string actualMessage = _messageBuilder.BuildOrderMessage(order);
            
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void given_inputEqualsOneOrderWithT_when_CreateReport_then_returns_resultsWithOneT()
        {
            listOfResponses = new List<string>() {"T::", "0.4"};
            listOfDecisions = new List<string>() {"y", "y", "n", "n"};
            _coffeeMachineEngine = new CoffeeMachineEngine(new TestUserInput(listOfResponses, listOfDecisions));

            List<Order> allOrders = _coffeeMachineEngine.CollectAllOrders();

            Report report = _reportBuilder.CreateReport(allOrders);

            Dictionary<string, double> expectedResults = new Dictionary<string, double>()
            {
                {"Tea", 1},
                {"Total Revenue", 0.4}
            };
            
            Assert.Equal(expectedResults, report._results);
        }
        
        [Fact]
        public void given_inputEqualsOneOrderWithTandCh_when_CreateReport_then_returns_resultsWithOneTeaAndOneCoffee()
        {
            listOfResponses = new List<string>() {"T::", "Ch:1:0", "1.0"};
            listOfDecisions = new List<string>() {"y", "y", "y", "n", "n"};
            _coffeeMachineEngine = new CoffeeMachineEngine(new TestUserInput(listOfResponses, listOfDecisions));

            List<Order> allOrders = _coffeeMachineEngine.CollectAllOrders();

            Report report = _reportBuilder.CreateReport(allOrders);

            Dictionary<string, double> expectedResults = new Dictionary<string, double>()
            {
                {"Tea", 1},
                {"Coffee", 1},
                {"Total Revenue", 1}
            };
            
            Assert.Equal(expectedResults, report._results);
        }

        public Order CreateOrder(string[] input)
        {
            List<Message> messages = new List<Message>();
            List<char> _validDrinkCodes = new List<char>() {'C', 'T', 'H', 'O'};

            foreach (var item in input)
            {
                if (_validDrinkCodes.Contains(item[0]))
                {
                    IDrink drink = _inputProcessor.ProcessInput(item);
                    Message message = new Message(drink);
                    messages.Add(message);
                }
                else if (item[0] == 'M')
                {
                    Message message = new Message(item);
                    messages.Add(message);
                }
            }
            
            Order order = new Order(messages);

            return order;
        }
    }
}