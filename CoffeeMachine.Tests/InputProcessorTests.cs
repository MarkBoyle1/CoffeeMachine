using System.Collections.Generic;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class InputProcessorTests
    {
        private List<string> _listOfResponses;
        private List<string> _listOfDecisions;

        private InputProcessor _inputProcessor;

        public InputProcessorTests()
        {
            _listOfResponses = new List<string>();
            _listOfDecisions = new List<string>();
            _inputProcessor = new InputProcessor(new TestUserInput(_listOfResponses, _listOfDecisions));
        }
        
        [Fact]
        public void given_inputEqualsT_when_CreateItem_then_GetDrinkType_returns_Tea()
        {
            Order order = new Order();
            order = _inputProcessor.AddInputToOrder("T::", order);

            IDrink drink = order.DrinkList[0];

            Assert.Equal("Tea", drink.GetDrinkType());
        }
        
        [Fact]
        public void given_inputEqualsH_when_CreateItem_then_GetDrinkType_returns_Chocolate()
        {
            Order order = new Order();
            order = _inputProcessor.AddInputToOrder("H::", order);

            IDrink drink = order.DrinkList[0];

            Assert.Equal("Chocolate", drink.GetDrinkType());
        }
        
        [Fact]
        public void given_inputEqualsT_when_CreateItem_then_GetSugarAmount_returns_0()
        {
            Order order = new Order();
            order = _inputProcessor.AddInputToOrder("T::", order);

            IDrink drink = order.DrinkList[0];

            Assert.Equal("0", drink.GetSugarAmount());
        }
        
        [Fact]
        public void given_inputEqualsT1_when_CreateItem_then_GetSugarAmount_returns_1()
        {
            Order order = new Order();
            order = _inputProcessor.AddInputToOrder("T:1:0", order);

            IDrink drink = order.DrinkList[0];

            Assert.Equal("1", drink.GetSugarAmount());
        }
        
        [Fact]
        public void given_inputIsAMessage_when_CreateItem_then_ItemType_returns_Message()
        {
            Order order = new Order();
            order = _inputProcessor.AddInputToOrder("M:TestMessage", order);

            Message message = order.MessageList[0];

            Assert.Equal("M:TestMessage", message.content);
        }
    }
}