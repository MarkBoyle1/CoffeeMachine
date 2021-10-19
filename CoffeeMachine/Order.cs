using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class Order
    {
        public List<IDrink> DrinkList { get; }

        public Order()
        {
            DrinkList = new List<IDrink>();
        }

        public void AddDrinkToOrder(IDrink drink)
        {
            DrinkList.Add(drink);
        }
    }
}