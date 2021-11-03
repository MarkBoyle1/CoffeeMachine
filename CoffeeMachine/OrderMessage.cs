namespace CoffeeMachine
{
    public class OrderMessage
    {
        public string content { get; }

        public OrderMessage(string input)
        {
            content = input;
        }
    }
}