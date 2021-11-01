namespace CoffeeMachine.Ingredients
{
    public class CoffeeBeans : IIngredient
    {
        public string name = "CoffeeBeans";
        private int stockLevel = IngredientStock.stockLevels["CoffeeBeans"];

        public bool isEmpty()
        {
            return stockLevel == 0;
        }
        
        public string GetIngredientName()
        {
            return name;
        }
    }
}