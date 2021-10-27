using Xunit;

namespace CoffeeMachine.Tests
{
    public class InputProcessorTests
    {
        InputProcessor _inputProcessor = new InputProcessor();
        
        [Fact]
        public void given_inputEqualsT_when_CreateItem_then_GetDrinkType_returns_Tea()
        {
            Item item = _inputProcessor.CreateItem("T::");

            Assert.Equal("Tea", item.ItemType);
        }
        
        [Fact]
        public void given_inputEqualsH_when_CreateItem_then_GetDrinkType_returns_Chocolate()
        {
            Item item = _inputProcessor.CreateItem("H::");
            
            Assert.Equal("Chocolate", item.ItemType);
        }
        
        [Fact]
        public void given_inputEqualsT_when_CreateItem_then_GetSugarAmount_returns_0()
        {
            Item item = _inputProcessor.CreateItem("T::");

            IDrink drink = item.ItemObject;
            
            Assert.Equal("0", drink.GetSugarAmount());
        }
        
        [Fact]
        public void given_inputEqualsT1_when_CreateItem_then_GetSugarAmount_returns_1()
        {
            Item item = _inputProcessor.CreateItem("T:1:0");
            
            IDrink drink = item.ItemObject;
            
            Assert.Equal("1", drink.GetSugarAmount());
        }
        
        [Fact]
        public void given_inputIsAMessage_when_CreateItem_then_ItemType_returns_Message()
        {
            Item item = _inputProcessor.CreateItem("M:TestMessage");

            Assert.Equal("Message", item.ItemType);
        }
        
        [Fact]
        public void given_inputIsAMessage_when_CreateItem_then_ItemValue_returns_0()
        {
            Item item = _inputProcessor.CreateItem("M:TestMessage");

            Assert.Equal(0, item.Value);
        }
        
        [Fact]
        public void given_inputIsAMessage_when_CreateItem_then_ItemObject_returns_MessageContent()
        {
            Item item = _inputProcessor.CreateItem("M:TestMessage");

            Message message = item.ItemObject;

            Assert.Equal("M:TestMessage", message.content);
        }

    }
}