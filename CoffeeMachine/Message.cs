namespace CoffeeMachine
{
    public class Message
    {
        private MessageBuilder _messageBuilder = new MessageBuilder();
        public string messageContent { get; }
        public string itemType { get; }
        public double value { get; }

        public Message(IDrink drink)
        {
            messageContent = _messageBuilder.BuildIndividualDrinkMessage(drink);
            itemType = drink.GetDrinkType();
            value = drink.GetPrice();
        }

        public Message(string input)
        {
            messageContent = input.Substring(2);
            itemType = "Message";
            value = 0;
        }
    }
}