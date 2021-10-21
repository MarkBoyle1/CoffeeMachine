using Xunit;

namespace CoffeeMachine.Tests
{
    public class InputProcessorTests
    {
        InputProcessor _inputProcessor = new InputProcessor();
        
        [Fact]
        public void given_inputEqualsT_when_ProcessInput_then_GetDrinkType_returns_Tea()
        {
            IDrink drink = _inputProcessor.ProcessInput("T::", 1);

            Assert.Equal("Tea", drink.GetDrinkType());
        }
        
        [Fact]
        public void given_inputEqualsH_when_ProcessInput_then_GetDrinkType_returns_Chocolate()
        {
            IDrink drink = _inputProcessor.ProcessInput("H::", 1);
            
            Assert.Equal("Chocolate", drink.GetDrinkType());
        }
        
        [Fact]
        public void given_inputEqualsT_when_ProcessInput_then_GetSugarAmount_returns_0()
        {
            IDrink drink = _inputProcessor.ProcessInput("T::", 1);
            
            Assert.Equal("0", drink.GetSugarAmount());
        }
        
        [Fact]
        public void given_inputEqualsT1_when_ProcessInput_then_GetSugarAmount_returns_1()
        {
            IDrink drink = _inputProcessor.ProcessInput("T:1:0", 1);
            
            Assert.Equal("1", drink.GetSugarAmount());
        }

    }
}