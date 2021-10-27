namespace CoffeeMachine
{
    public class Message
    {
        public string content { get; }

        public Message(string input)
        {
            content = input;
        }
    }
}