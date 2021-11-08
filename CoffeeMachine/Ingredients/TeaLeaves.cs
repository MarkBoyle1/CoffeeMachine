namespace CoffeeMachine.Ingredients
{
    public class TeaLeaves : IIngredient
    {
        public string name = "TeaLeaves";

        private int stockLevel = IngredientStock.stockLevels["TeaLeaves"];

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