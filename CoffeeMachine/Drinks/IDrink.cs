namespace CoffeeMachine
{
    public interface IDrink
    {
        string GetDrinkType();

        public string GetSugarAmount();

        IDrink AddSugar(string sugarAmount);
    }
}