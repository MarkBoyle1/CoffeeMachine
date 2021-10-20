using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class Order
    {
        public List<IDrink> DrinkList { get; }

        public Order(IDrink drink)
        {
            DrinkList = new List<IDrink>() {drink};
        }
        public Order(Order order, IDrink drink)
        {
            DrinkList = new List<IDrink>(order.DrinkList);
            DrinkList.Add(drink);
        }
    }
}