using System.Collections.Generic;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class MoneyTests
    {
        private List<string> listOfResponses;
        private List<string> listOfDecisions;
        private CoffeeMachineEngine _coffeeMachineEngine;
        private MessageBuilder _messageBuilder;
        private InputProcessor _inputProcessor;

        public MoneyTests()
        {
            listOfResponses = new List<string>() {"T::", "0.4"};
            listOfDecisions = new List<string>() {"y", "y", "n", "n"};
            _coffeeMachineEngine = new CoffeeMachineEngine(new TestUserInput(listOfResponses, listOfDecisions));
            _messageBuilder = new MessageBuilder();
            _inputProcessor = new InputProcessor();
        }
        
        [Fact]
        public void given_moneyInsertedIsLessThanPrice_when_CreateMessage_then_return_SorryNotEnoughMoneyIsInsertedMessage()
        {
            string[] input = new[] {"T::"};
            Order order = CreateOrder(input);
            double moneyInserted = 0.3;
            
    
            string expectedMessage = "Sorry, not enough money has been inserted. 0.1 more needed.";
            string actualMessage = _messageBuilder.BuildNotEnoughMoneyMessage(moneyInserted, order.TotalPrice);
            
            Assert.Equal(expectedMessage, actualMessage);
        }
        
        [Fact]
        public void given_noMoneyIsInserted_when_CreateMessage_then_return_SorryNotEnoughMoneyIsInsertedMessage()
        {
            string[] input = new[] {"T::"};
            Order order = CreateOrder(input);
            double moneyInserted = 0;
            
    
            string expectedMessage = "Sorry, not enough money has been inserted. 0.4 more needed.";
            string actualMessage = _messageBuilder.BuildNotEnoughMoneyMessage(moneyInserted, order.TotalPrice);
            
            Assert.Equal(expectedMessage, actualMessage);
        }
        
        [Fact]
        public void given_inputEqualsC1andH_and_moneyInsertedIsNotEnough_when_CreateMessage_then_return_SorryNotEnoughMoneyIsInsertedMessage()
        {
            string[] input = new[] {"C:1:", "H::"};
            Order order = CreateOrder(input);
            double moneyInserted = 0.8;
            
            string expectedMessage = "Sorry, not enough money has been inserted. 0.3 more needed.";
            string actualMessage = _messageBuilder.BuildNotEnoughMoneyMessage(moneyInserted, order.TotalPrice);
            
            Assert.Equal(expectedMessage, actualMessage);
        }
        
        [Fact]
        public void given_inputEqualsC1andHandT2_and_noMoneyIsInserted_when_CreateMessage_then_return_SorryNotEnoughMoneyIsInsertedMessage()
        {
            string[] input = new[] {"C:1:", "H::", "T:2:0"};
            Order order = CreateOrder(input);
            double moneyInserted = 0;
            
            string expectedMessage = "Sorry, not enough money has been inserted. 1.5 more needed.";
            string actualMessage = _messageBuilder.BuildNotEnoughMoneyMessage(moneyInserted, order.TotalPrice);
            
            Assert.Equal(expectedMessage, actualMessage);
        }
        
        [Fact]
        public void given_inputEqualsChandChandCh_and_moneyInsertedIsNotEnough_when_CreateMessage_then_returns_SorryNotEnoughMoneyIsInsertedMessage()
        {
            string[] input = new[] {"Ch::", "Ch::", "Ch::"};
            Order order = CreateOrder(input);
            double moneyInserted = 0.6;

            string expectedMessage = "Sorry, not enough money has been inserted. 1.2 more needed.";
            string actualMessage = _messageBuilder.BuildNotEnoughMoneyMessage(moneyInserted, order.TotalPrice);
            
            Assert.Equal(expectedMessage, actualMessage);
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
            
            Order order = new Order(messages);

            return order;
        }
    }
}