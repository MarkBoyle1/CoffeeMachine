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
                string message = BuildIndividualDrinkMessage(drink);
                orderMessage.Append(message);
            }

            return orderMessage.ToString();
        }
        
        private string BuildIndividualDrinkMessage(IDrink drink)
        {
            string drinkQuantity = " 1";
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

            return $"Make{drinkQuantity}{temperatureMessage}{drinkTypeMessage}{sugarMessage}\n";
        }

        public string BuildNotEnoughMoneyMessage(double moneyInserted, double price)
        {
            double missingAmount = Math.Round((price - moneyInserted), 1);
            return $"Sorry, not enough money has been inserted. {missingAmount} more needed.";
        }
    }
}