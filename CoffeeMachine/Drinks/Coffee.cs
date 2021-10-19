using System.Text;

namespace CoffeeMachine.Drinks
{
    public class Coffee : IDrink
    {
        private string _drinkType;
        private string _sugarAmount;
        private MessageBuilder _messageBuilder = new MessageBuilder();

        public Coffee(string sugarAmount)
        {
            _drinkType = "Coffee";
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