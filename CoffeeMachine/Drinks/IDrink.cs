namespace CoffeeMachine
{
    public interface IDrink
    {
        string GetDrinkType();
        
        string GetSugarAmount();

        double GetPrice();

        public DrinkTemperature GetDrinkTemperature();
    }
}