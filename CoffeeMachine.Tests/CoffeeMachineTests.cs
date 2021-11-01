using System;
using System.Collections.Generic;
using CoffeeMachine.Drinks;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class CoffeeMachineTests
    {
        private List<string> _listOfResponses;
        private List<string> _listOfDecisions;
        private CoffeeMachineEngine _coffeeMachineEngine;

        public CoffeeMachineTests()
        {
            _listOfResponses = new List<string>() {"T::"};
            _listOfDecisions = new List<string>() {"y", "y", "y", "n", "n"};
            _coffeeMachineEngine = new CoffeeMachineEngine(new TestUserInput(_listOfResponses, _listOfDecisions));
        }

        [Fact]
        public void given_inputEqualsOneOrderWithT_when_RunProgram_then_returns_resultsWithOneT()
        {
            _listOfResponses = new List<string>() {"T::", "0.4"};
            _listOfDecisions = new List<string>() {"y", "y", "n", "n"};
            _coffeeMachineEngine = new CoffeeMachineEngine(new TestUserInput(_listOfResponses, _listOfDecisions));

            Report report = _coffeeMachineEngine.RunProgram();

            Dictionary<string, double> expectedResults = new Dictionary<string, double>()
            {
                {"Tea", 1},
                {"Total Revenue", 0.4}
            };
            
            Assert.Equal(expectedResults, report._results);
        }
        
        [Fact]
        public void given_inputEqualsOneOrderWithTandCh_when_RunProgram_then_returns_resultsWithOneTeaAndOneCoffee()
        {
            _listOfResponses = new List<string>() {"T::", "Hh:1:0", "0.9"};
            _listOfDecisions = new List<string>() {"y", "y", "y", "n", "n"};
            _coffeeMachineEngine = new CoffeeMachineEngine(new TestUserInput(_listOfResponses, _listOfDecisions));

            Report report = _coffeeMachineEngine.RunProgram();

            Dictionary<string, double> expectedResults = new Dictionary<string, double>()
            {
                {"Tea", 1},
                {"Chocolate", 1},
                {"Total Revenue", 0.9}
            };
            
            Assert.Equal(expectedResults, report._results);
        }
        
        [Fact]
        public void given_inputEqualsOneOrderWithThreeDifferentCoffees_when_RunProgram_then_returns_resultsWithOneThreeCoffees()
        {
            _listOfResponses = new List<string>() {"H::", "Hh:1:0", "H:1:0", "1.5"};
            _listOfDecisions = new List<string>() {"y", "y", "y", "y", "n", "n"};
            _coffeeMachineEngine = new CoffeeMachineEngine(new TestUserInput(_listOfResponses, _listOfDecisions));

            Report report = _coffeeMachineEngine.RunProgram();

            Dictionary<string, double> expectedResults = new Dictionary<string, double>()
            {
                {"Chocolate", 3},
                {"Total Revenue", 1.5}
            };
            
            Assert.Equal(expectedResults, report._results);
        }
        
        [Fact]
        public void given_inputEqualsOneOrderWithT_and_notEnoughMoney_then_addExtraMoney_when_RunProgram_then_returns_resultsWithOneT()
        {
            _listOfResponses = new List<string>() {"T::", "0.3", "0.1"};
            _listOfDecisions = new List<string>() {"y", "y", "n", "n"};
            _coffeeMachineEngine = new CoffeeMachineEngine(new TestUserInput(_listOfResponses, _listOfDecisions));

            Report report = _coffeeMachineEngine.RunProgram();

            Dictionary<string, double> expectedResults = new Dictionary<string, double>()
            {
                {"Tea", 1},
                {"Total Revenue", 0.4}
            };
            
            Assert.Equal(expectedResults, report._results);
        }
        
        [Fact]
        public void given_inputEqualsOneOrderWithO_when_RunProgram_then_returns_resultsWithOneO()
        {
            _listOfResponses = new List<string>() {"O::", "0.6"};
            _listOfDecisions = new List<string>() {"y", "y", "n", "n"};
            _coffeeMachineEngine = new CoffeeMachineEngine(new TestUserInput(_listOfResponses, _listOfDecisions));

            Report report = _coffeeMachineEngine.RunProgram();

            Dictionary<string, double> expectedResults = new Dictionary<string, double>()
            {
                {"Orange Juice", 1},
                {"Total Revenue", 0.6}
            };
            
            Assert.Equal(expectedResults, report._results);
        }
    }
}