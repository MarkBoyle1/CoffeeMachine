using Xunit;

namespace CoffeeMachine.Tests
{
    public class MoneyTests
    {
        private CoffeeMachineEngine _coffeeMachineEngine = new CoffeeMachineEngine();
        
        [Fact]
        public void given_moneyInsertedIsLessThanPrice_when_CreateMessage_then_return_SorryNotEnoughMoneyIsInsertedMessage()
        {
            string message = _coffeeMachineEngine.CreateMessage("T::", "0.3");

            string expectedMessage = "Sorry, not enough money has been inserted. 0.1 more needed.";
            
            Assert.Equal(expectedMessage, message);
        }
        
        [Fact]
        public void given_noMoneyIsInserted_when_CreateMessage_then_return_SorryNotEnoughMoneyIsInsertedMessage()
        {
            string message = _coffeeMachineEngine.CreateMessage("T::");

            string expectedMessage = "Sorry, not enough money has been inserted. 0.4 more needed.";
            
            Assert.Equal(expectedMessage, message);
        }
        
        [Fact]
        public void given_inputEqualsC1andH_and_moneyInsertedIsNotEnough_when_CreateMessage_then_return_SorryNotEnoughMoneyIsInsertedMessage()
        {
            string message = _coffeeMachineEngine.CreateMessage("C:1:", "H::", "0.8");

            string expectedMessage = "Sorry, not enough money has been inserted. 0.3 more needed.";
            
            Assert.Equal(expectedMessage, message);
        }
        
        [Fact]
        public void given_inputEqualsC1andHandT2_and_noMoneyIsInserted_when_CreateMessage_then_return_SorryNotEnoughMoneyIsInsertedMessage()
        {
            string message = _coffeeMachineEngine.CreateMessage("C:1:", "H::", "T:2:0");

            string expectedMessage = "Sorry, not enough money has been inserted. 1.5 more needed.";
            
            Assert.Equal(expectedMessage, message);
        }
    }
}