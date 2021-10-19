using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class MessageBuilder
    {
        public string BuildOrderMessage(List<IDrink> orderList)
        {
            StringBuilder orderMessage = new StringBuilder();

            foreach (var drink in orderList)
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
    }
}