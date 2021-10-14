using System;

namespace CoffeeMachine
{
    public class Order
    {
        private string _drink;
        private string _sugarAmount;
        private bool _requiresStick;

        public string CreateOrder(string input)
        {
            string[] splitInput = input.Split(':', StringSplitOptions.RemoveEmptyEntries);

            _drink = splitInput[0];
            _sugarAmount = splitInput.Length > 1 ? splitInput[1] : "0";
            _requiresStick = splitInput.Length == 3;

            return input;
        }

        public string GetDrink()
        {
            return _drink;
        }

        public string GetSugarAmount()
        {
            return _sugarAmount;
        }

        public bool RequiresStick()
        {
            return _requiresStick;
        }
    }
}