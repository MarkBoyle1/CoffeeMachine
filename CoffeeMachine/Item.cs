namespace CoffeeMachine
{
    public class Item
    {
        private MessageBuilder _messageBuilder = new MessageBuilder();
        public string messageContent { get; }
        public string itemType { get; }
        public double value { get; }

        public Item(IDrink drink)
        {
            messageContent = _messageBuilder.BuildIndividualDrinkMessage(drink);
            itemType = drink.GetDrinkType();
            value = drink.GetPrice();
        }

        public Item(string input)
        {
            messageContent = input.Substring(2);
            itemType = "Message";
            value = 0;
        }
    }
}