using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class Order
    {
        public List<Item> ItemList { get; }
        public double TotalPrice { get; }
        
        public Order(List<Item> input, double totalPrice)
        {
            ItemList = input;
            TotalPrice = totalPrice;
        }
    }
}