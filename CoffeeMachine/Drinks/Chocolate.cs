using System.Text;

namespace CoffeeMachine.Drinks
{
    public class Chocolate : IDrink
    {
        public string _drinkType;
        public string _sugarAmount;
        private MessageBuilder _messageBuilder = new MessageBuilder();

        public Chocolate(string sugarAmount)
        {
            _drinkType = "Chocolate";
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