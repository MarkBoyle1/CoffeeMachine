using System.Text;

namespace CoffeeMachine.Drinks
{
    public class Tea : IDrink
    {
        public string _drinkType;
        private string _sugarAmount { get; set; }
        private MessageBuilder _messageBuilder = new MessageBuilder();

        public Tea(string sugarAmount)
        {
            _drinkType = "Tea";
            _sugarAmount = sugarAmount;
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