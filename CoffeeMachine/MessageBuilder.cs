using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class MessageBuilder
    {
        public string BuildOrderMessage(Order order)
        {
            StringBuilder orderMessage = new StringBuilder();

            foreach (var drink in order.DrinkList)
            {
                string message = BuildIndividualDrinkMessage(drink.GetDrinkType(), drink.GetSugarAmount());
                orderMessage.Append(message);
            }

            return orderMessage.ToString();
        }
        
        private string BuildIndividualDrinkMessage(string _drinkType, string _sugarAmount)
        {
            StringBuilder message = new StringBuilder();
            
            string drinkMessage = $"1 {_drinkType}";

            string sugar = _sugarAmount != "0" ? _sugarAmount : "no";
            string sugarMessage = $" with {sugar} sugar";

            string stick = sugar == "no" ? " and no stick" : " and a stick";
            string stickMessage = $"{stick}";

            message.Append($"Make {drinkMessage}{sugarMessage}{stickMessage}\n");
                
            return message.ToString();
        }

        public string BuildNotEnoughMoneyMessage(double moneyInserted, double price)
        {
            double missingAmount = Math.Round((price - moneyInserted), 1);
            return $"Sorry, not enough money has been inserted. {missingAmount} more needed.";
        }
    }
}