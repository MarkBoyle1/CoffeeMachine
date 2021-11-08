namespace CoffeeMachine.Ingredients
{
    public class Oranges : IIngredient
    {
        public string name = "Oranges";

        private int stockLevel = IngredientStock.stockLevels["Oranges"];
        
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