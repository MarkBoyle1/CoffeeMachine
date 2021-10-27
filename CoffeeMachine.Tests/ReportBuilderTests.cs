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
            List<Item> itemList = new List<Item>()
            {
                new Item(_sampleDrinks[0]),
                new Item(_sampleDrinks[1]),
                new Item(_sampleDrinks[2]),
                new Item(_sampleDrinks[3])
            };

            List<Order> orders = new List<Order>()
            {
                new Order(itemList, 2.2)
            };
        
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
            List<Item> itemList = new List<Item>()
            {
                new Item(_sampleDrinks[3]),
                new Item(_sampleDrinks[4]),
                new Item(_sampleDrinks[5]),
                new Item(_sampleDrinks[6])
            };

            List<Order> orders = new List<Order>()
            {
                new Order(itemList, 2)
            };
        
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
            List<Item> itemList1 = new List<Item>()
            {
                new Item(_sampleDrinks[3]),
                new Item(_sampleDrinks[4]),
                new Item(_sampleDrinks[5]),
                new Item(_sampleDrinks[6])
            };
            
            List<Item> itemList2 = new List<Item>()
            {
                new Item(_sampleDrinks[0]),
                new Item(_sampleDrinks[0]),
                new Item(_sampleDrinks[4]),
                new Item(_sampleDrinks[6])
            };

            List<Order> orders = new List<Order>()
            {
                new Order(itemList1, 2),
                new Order(itemList2, 2)

            };
        
            Report report = _reportBuilder.CreateReport(orders);
        
            Dictionary<string, double> results = new Dictionary<string, double>()
            {
                {"Coffee", 1},
                {"Tea", 3},
                {"Orange Juice", 2},
                {"Chocolate", 2},
                {"Total Revenue", 4}
            };
        
            Assert.Equal(results, report._results);
        }
    }
}