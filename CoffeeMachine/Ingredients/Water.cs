namespace CoffeeMachine.Ingredients
{
    public class Water : IIngredient
    {
        public string name = "Water";

        private int stockLevel = IngredientStock.stockLevels["Water"];

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