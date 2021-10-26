using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class Order
    {
        public List<Message> ItemList { get; }
        public double TotalPrice { get; }

        // public Order()
        // {
        //     DrinkList = new List<IDrink>();
        //     TotalPrice = 0;
        // }
        // public Order(Order order, IDrink drink)
        // {
        //     DrinkList = new List<IDrink>(order.DrinkList);
        //     DrinkList.Add(drink);
        //     TotalPrice = order.TotalPrice + drink.GetPrice();
        // }
        //
        public Order(List<Message> input)
        {
            ItemList = input;
            TotalPrice = GetOrderPrice(input);
        }

        private double GetOrderPrice(List<Message> input)
        {
            double totalPrice = 0;

            foreach (var message in input)
            {
                totalPrice += message.value;
            }

            return totalPrice;
        }
    }
}