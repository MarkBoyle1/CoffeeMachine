using System.Collections.Generic;
using CoffeeMachine.Drinks;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class MessageBuilderTests
    {
        private MessageBuilder _messageBuilder = new MessageBuilder();
        private List<IDrink> _sampleDrinks;

        public MessageBuilderTests()
        {
            _sampleDrinks = new List<IDrink>()
            {
                new Chocolate("0", DrinkTemperature.Normal),
                new Chocolate("1", DrinkTemperature.ExtraHot),
                new Coffee("2", DrinkTemperature.ExtraHot),
                new Coffee("0", DrinkTemperature.Normal),
                new Tea("1", DrinkTemperature.Normal),
                new Tea("0", DrinkTemperature.ExtraHot),
                new OrangeJuice()
            };
        }
        
        [Fact]
        public void given_drinkEqualsCh1_when_BuildIndividualMessage_then_returns_Make_1_extra_hot_Chocolate_with_1_sugar_and_a_stick()
        {
            IDrink drink = new Chocolate("1", DrinkTemperature.ExtraHot);

            string message = _messageBuilder.BuildIndividualMessage(drink);

            Assert.Equal("Make 1 extra hot Chocolate with 1 sugar and a stick\n", message);
        }
        
        [Fact]
        public void given_drinkEqualsC1_when_BuildIndividualMessage_then_returns_Make_1_Chocolate_with_1_sugar_and_a_stick()
        {
            IDrink drink = new Chocolate("1", DrinkTemperature.Normal);

            string message = _messageBuilder.BuildIndividualMessage(drink);

            Assert.Equal("Make 1 Chocolate with 1 sugar and a stick\n", message);
        }
        
        [Fact]
        public void given_drinkEqualsT_when_BuildIndividualMessage_then_returns_Make_1_Tea_with_no_sugar_and_no_stick()
        {
            IDrink drink = new Tea("0", DrinkTemperature.Normal);

            string message = _messageBuilder.BuildIndividualMessage(drink);

            Assert.Equal("Make 1 Tea with no sugar and no stick\n", message);
        }
        
        [Fact]
        public void given_drinkEqualsO_when_BuildIndividualMessage_then_returns_Make_1_Tea_with_no_sugar_and_no_stick()
        {
            IDrink drink = new OrangeJuice();

            string message = _messageBuilder.BuildIndividualMessage(drink);

            Assert.Equal("Make 1 Orange Juice\n", message);
        }
        
        [Fact]
        public void given_inputEqualsMessage_when_BuildIndividualMessage_then_returns_MessageContent()
        {
            Message inputMessage = new Message("M:TestMessage");

            string message = _messageBuilder.BuildIndividualMessage(inputMessage);

            Assert.Equal("TestMessage\n", message);
        }
        
        [Fact]
        public void given_OrderPriceEquals1point2_and_moneyInsertEquals0point8_when_BuildNotEnoughMoneyMessage_then_returns_CorrectMessage()
        {
            OrderMessage message = _messageBuilder.BuildNotEnoughMoneyMessage(0.8, 1.2);

            Assert.Equal("Sorry, not enough money has been inserted. 0.4 more needed.", message.content);
        }
        
        [Fact]
        public void given_OrderContainsFourDrinks_when_BuildOrderMessage_then_returns_CorrectMessage()
        {
            Order order = new Order();
            
            order = new Order(order, _sampleDrinks[0]);
            order = new Order(order, _sampleDrinks[1]);
            order = new Order(order, _sampleDrinks[2]);
            order = new Order(order, _sampleDrinks[3]);
            
            OrderMessage message = _messageBuilder.BuildOrderMessage(order);

            string expectedMessage = "Make 1 Chocolate with no sugar and no stick\n" +
                                     "Make 1 extra hot Chocolate with 1 sugar and a stick\n" +
                                     "Make 1 extra hot Coffee with 2 sugar and a stick\n" +
                                     "Make 1 Coffee with no sugar and no stick\n";

            Assert.Equal(expectedMessage, message.content);
        }
        
        [Fact]
        public void given_OrderContainsThreeDrinksAndAMessage_when_BuildOrderMessage_then_returns_CorrectMessage()
        {
            Message messageContent = new Message("M:No Milk Available");
            
            Order order = new Order();
            
            order = new Order(order, _sampleDrinks[0]);
            order = new Order(order, messageContent);
            order = new Order(order, _sampleDrinks[2]);
            order = new Order(order, _sampleDrinks[3]);
            
            OrderMessage message = _messageBuilder.BuildOrderMessage(order);

            string expectedMessage = "Make 1 Chocolate with no sugar and no stick\n" +
                                     "Make 1 extra hot Coffee with 2 sugar and a stick\n" +
                                     "Make 1 Coffee with no sugar and no stick\n" +
                                     "No Milk Available\n";

            Assert.Equal(expectedMessage, message.content);
        }
    }
}