namespace CoffeeMachine
{
    public interface IStockLevelDatabase
    {
        int GetStockLevel(string ingredient);
    }
}