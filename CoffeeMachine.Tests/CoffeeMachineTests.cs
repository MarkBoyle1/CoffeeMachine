using System;
using CoffeeMachine.Drinks;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class CoffeeMachineTests
    {
        private CoffeeMachineEngine _coffeeMachineEngine = new CoffeeMachineEngine();
        
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

            string expectedMessage = "Make 1 Coffee with 1 sugar and a stick\n" +
                                     "Make 1 Chocolate with no sugar and no stick\n";
            
            Assert.Equal(expectedMessage, message);
        }
        
        [Fact]
        public void given_inputEqualsO_when_CreateMessage_then_returns_Make_1_Orange_Juice()
        {
            string message = _coffeeMachineEngine.CreateMessage("O::", "0.6");

            string expectedMessage = "Make 1 Orange Juice\n";
            
            Assert.Equal(expectedMessage, message);
        }
        
        [Fact]
        public void given_inputEqualsCh_when_CreateMessage_then_returns_Make_1_Extra_Hot_Coffee_with_no_sugar_and_no_stick()
        {
            string message = _coffeeMachineEngine.CreateMessage("Ch::", "0.6");

            string expectedMessage = "Make 1 extra hot Coffee with no sugar and no stick\n";
            
            Assert.Equal(expectedMessage, message);
        }
        
        [Fact]
        public void given_inputEqualsChandChandCh_when_CreateMessage_then_returns_Make_3_Extra_Hot_Coffee_with_no_sugar_and_no_stick()
        {
            string message = _coffeeMachineEngine.CreateMessage("Ch::", "Ch::", "Ch::", "1.8");

            string expectedMessage = "Make 3 extra hot Coffee with no sugar and no stick\n";
            
            Assert.Equal(expectedMessage, message);
        }
        
        [Fact]
        public void given_inputEqualsChandChandC_when_CreateMessage_then_returns_TwoSeparateStatements()
        {
            string message = _coffeeMachineEngine.CreateMessage("Ch::", "Ch::", "C::", "1.8");

            string expectedMessage = "Make 2 extra hot Coffee with no sugar and no stick\n" +
                                     "Make 1 Coffee with no sugar and no stick\n";
            
            Assert.Equal(expectedMessage, message);
        }
    }
}