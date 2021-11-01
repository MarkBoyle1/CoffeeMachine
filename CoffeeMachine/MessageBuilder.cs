using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeMachine
{
    public class MessageBuilder
    {
        public string BuildOrderMessage(Order order)
        {
            StringBuilder orderMessage = new StringBuilder();

            foreach (IDrink drink in order.DrinkList)
            {
                string message = BuildIndividualMessage(drink);
                orderMessage.Append(message);
            }
            
            foreach (Message messageContent in order.MessageList)
            {
                string message = BuildIndividualMessage(messageContent);
                orderMessage.Append(message);
            }

            return orderMessage.ToString();
        }
        
        public string BuildIndividualMessage(IDrink drink)
        {
            string sugarMessage = "";
            string sugarAmount = drink.GetSugarAmount();
            string drinkTemperature = drink.GetDrinkTemperature().ToString();
            string drinkTypeMessage = $" {drink.GetDrinkType()}";

            if (sugarAmount != null)
            {
                sugarMessage = sugarAmount != "0" 
                    ? $" with {sugarAmount} sugar and a stick" 
                    : " with no sugar and no stick";
            }

            string temperatureMessage = drinkTemperature == "normal" 
                ? "" 
                : " " + drinkTemperature.Replace('_', ' ');

            return $"Make 1{temperatureMessage}{drinkTypeMessage}{sugarMessage}\n";
        }

        public string BuildIndividualMessage(Message message)
        {
            return message.content.Substring(2) + "\n";
        }

        public string BuildNotEnoughMoneyMessage(double moneyInserted, double price)
        {
            double missingAmount = Math.Round((price - moneyInserted), 1);
            return $"Sorry, not enough money has been inserted. {missingAmount} more needed.";
        }
    }
}