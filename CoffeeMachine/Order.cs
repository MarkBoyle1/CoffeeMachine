using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class Order
    {
        private List<IDrink> _drinkList;

        public Order()
        {
            _drinkList = new List<IDrink>();
        }

        public Order AddDrinkToOrder(IDrink drink)
        {
            _drinkList.Add(drink);
            return this;
        }

        public string BuildMessage()
        {
            StringBuilder message = new StringBuilder();
            
            foreach (var drink in _drinkList)
            {
                string drinkMessage = $"1 {drink.GetDrinkType()}";

                string sugar = drink.GetSugarAmount() != "0" ? drink.GetSugarAmount() : "no";
                string sugarMessage = $" with {sugar} sugar";

                string stick = sugar == "no" ? " and no stick" : " and a stick";
                string stickMessage = $"{stick}";

                message.Append($"Make {drinkMessage}{sugarMessage}{stickMessage}\n");
            }

            return message.ToString();
        }
    }
}