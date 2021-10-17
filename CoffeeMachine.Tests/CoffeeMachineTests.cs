using System;
using CoffeeMachine.Drinks;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class CoffeeMachineTests
    {
        private CoffeeMachineEngine _coffeeMachineEngine = new CoffeeMachineEngine();

        [Fact]
        public void given_inputEqualsT_when_ProcessInput_then_GetDrinkType_returns_Tea()
        {
            InputProcessor _inputProcessor = new InputProcessor();

            IDrink drink = _inputProcessor.ProcessInput("T::");
            
            Assert.Equal("Tea", drink.GetDrinkType());
        }
        
        [Fact]
        public void given_inputEqualsH_when_ProcessInput_then_GetDrinkType_returns_Chocolate()
        {
            InputProcessor _inputProcessor = new InputProcessor();

            IDrink drink = _inputProcessor.ProcessInput("H::");
            
            Assert.Equal("Chocolate", drink.GetDrinkType());
        }
        
        [Fact]
        public void given_inputEqualsT_when_ProcessInput_then_GetSugarAmount_returns_0()
        {
            InputProcessor _inputProcessor = new InputProcessor();

            IDrink drink = _inputProcessor.ProcessInput("T::");
            
            Assert.Equal("0", drink.GetSugarAmount());
        }
        
        [Fact]
        public void given_inputEqualsT1_when_ProcessInput_then_GetSugarAmount_returns_1()
        {
            InputProcessor _inputProcessor = new InputProcessor();

            IDrink drink = _inputProcessor.ProcessInput("T:1:");
            
            Assert.Equal("1", drink.GetSugarAmount());
        }
        
        [Fact]
        public void given_inputEqualsT_when_CreateOrder_then_returns_Make_1_Tea_with_no_sugar_and_no_stick()
        {
            CoffeeMachineEngine _coffeeMachineEngine = new CoffeeMachineEngine();

            string message = _coffeeMachineEngine.CreateOrder("T::");

            string expectedMessage = "Make 1 Tea with no sugar and no stick\n";
            
            Assert.Equal(expectedMessage, message);
        }
        
        [Fact]
        public void given_inputEqualsT1_when_CreateOrder_then_returns_Make_1_Tea_with_1_sugar_and_a_stick()
        {
            CoffeeMachineEngine _coffeeMachineEngine = new CoffeeMachineEngine();

            string message = _coffeeMachineEngine.CreateOrder("T:1:");

            string expectedMessage = "Make 1 Tea with 1 sugar and a stick\n";
            
            Assert.Equal(expectedMessage, message);
        }
        
        [Fact]
        public void given_inputEqualsC1_when_CreateOrder_then_returns_Make_1_Coffee_with_1_sugar_and_a_stick()
        {
            CoffeeMachineEngine _coffeeMachineEngine = new CoffeeMachineEngine();

            string message = _coffeeMachineEngine.CreateOrder("C:1:");

            string expectedMessage = "Make 1 Coffee with 1 sugar and a stick\n";
            
            Assert.Equal(expectedMessage, message);
        }
    }
}