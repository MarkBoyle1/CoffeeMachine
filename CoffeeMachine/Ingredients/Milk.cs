namespace CoffeeMachine.Ingredients
{
    public class Milk : IIngredient
    {
        public string name = "Milk";
        private int stockLevel = IngredientStock.stockLevels["Milk"];

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