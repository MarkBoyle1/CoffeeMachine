using System;
using CoffeeMachine.Drinks;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class CoffeeMachineTests
    {
        private CoffeeMachineEngine _coffeeMachineEngine = new CoffeeMachineEngine();
        InputProcessor _inputProcessor = new InputProcessor();
        
        [Fact]
        public void given_inputEqualsT_when_ProcessInput_then_GetDrinkType_returns_Tea()
        {
            IDrink drink = _inputProcessor.ProcessInput("T::");

            Assert.Equal("Tea", drink.GetDrinkType());
        }
        
        [Fact]
        public void given_inputEqualsH_when_ProcessInput_then_GetDrinkType_returns_Chocolate()
        {
            IDrink drink = _inputProcessor.ProcessInput("H::");
            
            Assert.Equal("Chocolate", drink.GetDrinkType());
        }
        
        [Fact]
        public void given_inputEqualsT_when_ProcessInput_then_GetSugarAmount_returns_0()
        {
            IDrink drink = _inputProcessor.ProcessInput("T::");
            
            Assert.Equal("0", drink.GetSugarAmount());
        }
        
        [Fact]
        public void given_inputEqualsT1_when_ProcessInput_then_GetSugarAmount_returns_1()
        {
            IDrink drink = _inputProcessor.ProcessInput("T:1:0");
            
            Assert.Equal("1", drink.GetSugarAmount());
        }
        
        [Fact]
        public void given_inputEqualsT_when_CreateMessage_then_returns_Make_1_Tea_with_no_sugar_and_no_stick()
        {
            string message = _coffeeMachineEngine.CreateMessage("T::", "0.4");

            string expectedMessage = "Make 1 Tea with no sugar and no stick\n";
            
            Assert.Equal(expectedMessage, message);
        }
        
        [Fact]
        public void given_inputEqualsT1_when_CreateMessage_then_returns_Make_1_Tea_with_1_sugar_and_a_stick()
        {
            string message = _coffeeMachineEngine.CreateMessage("T:1:", "0.4");

            string expectedMessage = "Make 1 Tea with 1 sugar and a stick\n";
            
            Assert.Equal(expectedMessage, message);
        }
        
        [Fact]
        public void given_inputEqualsC1_when_CreateMessage_then_returns_Make_1_Coffee_with_1_sugar_and_a_stick()
        {
            string message = _coffeeMachineEngine.CreateMessage("C:1:", "0.6");

            string expectedMessage = "Make 1 Coffee with 1 sugar and a stick\n";
            
            Assert.Equal(expectedMessage, message);
        }
        
        [Fact]
        public void given_inputEqualsMtest_when_CreateMessage_then_returns_test()
        {
            string message = _coffeeMachineEngine.CreateMessage("M:test");

            string expectedMessage = "test";
            
            Assert.Equal(expectedMessage, message);
        }
        
        [Fact]
        public void given_inputEqualsC1andH_when_CreateMessage_then_returns_Make_1_Coffee_with_1_sugar_and_a_stick()
        {
            string message = _coffeeMachineEngine.CreateMessage("C:1:", "H::", "1.1");

            string expectedMessage = "Make 1 Coffee with 1 sugar and a stick\nMake 1 Chocolate with no sugar and no stick\n";
            
            Assert.Equal(expectedMessage, message);
        }
    }
}