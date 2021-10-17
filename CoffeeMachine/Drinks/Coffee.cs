namespace CoffeeMachine.Drinks
{
    public class Coffee : IDrink
    {
        private string _drinkType;
        private string _sugarAmount;

        public Coffee()
        {
            _drinkType = "Coffee";
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