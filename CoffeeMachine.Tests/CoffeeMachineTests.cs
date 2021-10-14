using System;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class CoffeeMachineTests
    {
        private CoffeeMachineEngine _coffeeMachineEngine = new CoffeeMachineEngine();
        [Fact]
        public void CreateOrder()
        {
            Order _order = new Order();

            _order.CreateOrder("T:1:O");

            Assert.Equal("T", _order.GetDrink());
            Assert.Equal("1", _order.GetSugarAmount());
            Assert.True(_order.RequiresStick());
        }
        
        [Fact]
        public void CreateOrderWithoutStick()
        {
            Order _order = new Order();

            _order.CreateOrder("T:1:");

            Assert.Equal("T", _order.GetDrink());
            Assert.Equal("1", _order.GetSugarAmount());
            Assert.False(_order.RequiresStick());
        }
    }
}