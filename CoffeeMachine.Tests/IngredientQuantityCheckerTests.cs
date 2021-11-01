using System.Collections.Generic;
using CoffeeMachine.Drinks;
using CoffeeMachine.Ingredients;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class IngredientQuantityCheckerTests
    {
        private InputProcessor _inputProcessor = new InputProcessor();
        private IngredientQuantityChecker _ingredientQuantityChecker = new IngredientQuantityChecker();
        private List<IDrink> _sampleDrinks;


        public IngredientQuantityCheckerTests()
        {
            _sampleDrinks = new List<IDrink>()
            {
                new Chocolate("0", DrinkTemperature.normal),
                new Chocolate("1", DrinkTemperature.extra_hot),
                new Coffee("2", DrinkTemperature.extra_hot),
                new Coffee("0", DrinkTemperature.normal),
                new Tea("1", DrinkTemperature.normal),
                new Tea("0", DrinkTemperature.extra_hot),
                new OrangeJuice()
            };
        }
        
        [Fact]
        public void given_drinkEqualsChocolate_and_StockLevelsAreFull_when_CanMakeDrink_then_return_True()
        {
            Order order = new Order();
            order = new Order(order, _sampleDrinks[2]);

            List<IIngredient> emptyingredients = _ingredientQuantityChecker.CheckForEmptyIngredients(order);

            string firstEmptyIngredient = emptyingredients[0].GetIngredientName();

            string expectedAnswer = "CoffeeBeans";

            Assert.Equal(firstEmptyIngredient, expectedAnswer);
        }
    }
}