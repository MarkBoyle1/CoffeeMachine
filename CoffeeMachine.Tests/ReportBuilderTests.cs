using System.Collections.Generic;
using CoffeeMachine.Drinks;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class ReportBuilderTests
    {
        
        private ReportBuilder _reportBuilder;
        private List<IDrink> _sampleDrinks;

        public ReportBuilderTests()
        {
            _reportBuilder = new ReportBuilder();
            _sampleDrinks = new List<IDrink>()
            {
                new Chocolate("0", DrinkTemperature.normal),
                new Chocolate("1", DrinkTemperature.extra_hot),
                new Coffee("2", DrinkTemperature.extra_hot),
                new Coffee("0", DrinkTemperature.normal),
                new Tea("1", DrinkTemperature.normal),
                new Tea("0", DrinkTemperature.extra_hot),
                new OrangeJuice()
            };
        }

        [Fact]
        public void given_twoOrderContainsThreeDrinksEach_when_CreateReport_then_return_reportWithDictionaryOfSales1()
        {
            Order order = new Order();
            
            order = new Order(order, _sampleDrinks[0]);
            order = new Order(order, _sampleDrinks[1]);
            order = new Order(order, _sampleDrinks[2]);
            order = new Order(order, _sampleDrinks[3]);

            List<Order> orders = new List<Order>() {order};
        
            Report report = _reportBuilder.CreateReport(orders);
        
            Dictionary<string, double> results = new Dictionary<string, double>()
            {
                {"Coffee", 2},
                {"Chocolate", 2},
                {"Total Revenue", 2.2}
            };
        
            Assert.Equal(results, report._results);
        }
        
        [Fact]
        public void given_twoOrderContainsThreeDrinksEach_when_CreateReport_then_return_reportWithDictionaryOfSales2()
        {
            Order order = new Order();
            
            order = new Order(order, _sampleDrinks[3]);
            order = new Order(order, _sampleDrinks[4]);
            order = new Order(order, _sampleDrinks[5]);
            order = new Order(order, _sampleDrinks[6]);

            List<Order> orders = new List<Order>() {order};
        
            Report report = _reportBuilder.CreateReport(orders);
        
            Dictionary<string, double> results = new Dictionary<string, double>()
            {
                {"Coffee", 1},
                {"Tea", 2},
                {"Orange Juice", 1},
                {"Total Revenue", 2}
            };
        
            Assert.Equal(results, report._results);
        }
        
        [Fact]
        public void given_twoOrderContainsThreeDrinksEach_when_CreateReport_then_return_reportWithDictionaryOfSales3()
        {
            Order order1 = new Order();
            
            order1 = new Order(order1, _sampleDrinks[0]);
            order1 = new Order(order1, _sampleDrinks[1]);
            order1 = new Order(order1, _sampleDrinks[2]);
            order1 = new Order(order1, _sampleDrinks[3]);
            
            Order order2 = new Order();
            
            order2 = new Order(order2, _sampleDrinks[0]);
            order2 = new Order(order2, _sampleDrinks[0]);
            order2 = new Order(order2, _sampleDrinks[4]);
            order2 = new Order(order2, _sampleDrinks[6]);

            List<Order> orders = new List<Order>()
            {
                order1,
                order2

            };
        
            Report report = _reportBuilder.CreateReport(orders);
        
            Dictionary<string, double> results = new Dictionary<string, double>()
            {
                {"Coffee", 2},
                {"Tea", 1},
                {"Orange Juice", 1},
                {"Chocolate", 4},
                {"Total Revenue", 4.2}
            };
        
            Assert.Equal(results, report._results);
        }
    }
}