using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class Order
    {
        public List<IDrink> DrinkList { get; }
        public double TotalPrice { get; }

        public Order()
        {
            DrinkList = new List<IDrink>();
            TotalPrice = 0;
        }
        public Order(Order order, IDrink drink)
        {
            DrinkList = new List<IDrink>(order.DrinkList);
            DrinkList.Add(drink);
            TotalPrice = order.TotalPrice + drink.GetPrice();
        }
    }
}