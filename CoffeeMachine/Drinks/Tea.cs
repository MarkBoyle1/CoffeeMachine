namespace CoffeeMachine.Drinks
{
    public class Tea : IDrink
    {
        private string _drinkType;
        private string _sugarAmount;

        public Tea()
        {
            _drinkType = "Tea";
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