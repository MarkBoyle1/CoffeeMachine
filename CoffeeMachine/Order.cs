using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class Order
    {
        public List<IDrink> DrinkList { get; }
        public List<Message> MessageList { get; }
        public double TotalPrice { get; }

        public Order()
        {
            DrinkList = new List<IDrink>();
            MessageList = new List<Message>();
            TotalPrice = 0;
        }

        public Order(Order order, IDrink drink)
        {
            DrinkList = order.DrinkList;
            DrinkList.Add(drink);
            MessageList = order.MessageList;
            TotalPrice = order.TotalPrice + drink.GetPrice();
        }

        public Order(Order order, Message message)
        {
            DrinkList = order.DrinkList;
            MessageList = order.MessageList;
            MessageList.Add(message);
            TotalPrice = order.TotalPrice;
        }
    }
}