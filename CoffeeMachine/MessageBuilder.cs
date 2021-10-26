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

            foreach (var message in order.ItemList)
            {
                if (message.itemType != "Message")
                {
                    orderMessage.Append(message.messageContent);
                }
            }

            return orderMessage.ToString();
        }
        
        public string BuildIndividualDrinkMessage(IDrink drink)
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

        public string BuildNotEnoughMoneyMessage(double moneyInserted, double price)
        {
            double missingAmount = Math.Round((price - moneyInserted), 1);
            return $"Sorry, not enough money has been inserted. {missingAmount} more needed.";
        }
    }
}