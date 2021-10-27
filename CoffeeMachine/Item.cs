namespace CoffeeMachine
{
    public class Item
    {
        private MessageBuilder _messageBuilder = new MessageBuilder();
        public string ItemType { get; }
        public double Value { get; }
        public dynamic ItemObject { get; }

        public Item(IDrink drink)
        {
            ItemType = drink.GetDrinkType();
            Value = drink.GetPrice();
            ItemObject = drink;
        }

        public Item(string input)
        {
            ItemType = "Message";
            Value = 0;
            ItemObject = new Message(input);
        }
    }
}