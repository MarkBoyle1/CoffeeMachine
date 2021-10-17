namespace CoffeeMachine.Drinks
{
    public class Chocolate : IDrink
    {
        private string _drinkType;
        private string _sugarAmount;

        public Chocolate()
        {
            _drinkType = "Chocolate";
        }
        
        
        public string GetDrinkType()
        {
            return _drinkType;
        }
        
        public string GetSugarAmount()
        {
            return _sugarAmount;
        }
        
        public IDrink AddSugar(string sugarAmount)
        {
            _sugarAmount = sugarAmount;
            return this;
        }
    }
}