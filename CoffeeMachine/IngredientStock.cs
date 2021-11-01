using System.Collections.Generic;

namespace CoffeeMachine
{
    public static class IngredientStock
    {
        public static Dictionary<string, int> stockLevels = new Dictionary<string, int>()
        {
            {"ChocolateFlakes", 23},
            {"CoffeeBeans", 0},
            {"Milk", 56},
            {"Oranges", 15},
            {"TeaLeaves", 32},
            {"Water", 56}
        };

    }
}