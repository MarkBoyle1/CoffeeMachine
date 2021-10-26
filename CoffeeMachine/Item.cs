namespace CoffeeMachine
{
    public class Item
    {
        private MessageBuilder _messageBuilder = new MessageBuilder();
        public string itemType { get; }
        public double value { get; }
        public dynamic item { get; }

        public Item(IDrink drink)
        {
            itemType = drink.GetDrinkType();
            value = drink.GetPrice();
            item = drink;
        }

        public Item(string input)
        {
            itemType = "Message";
            value = 0;
            item = new Message(input);
        }
    }
}