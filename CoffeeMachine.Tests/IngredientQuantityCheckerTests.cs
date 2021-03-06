using System.Collections.Generic;
using CoffeeMachine.Drinks;
using CoffeeMachine.Ingredients;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class IngredientQuantityCheckerTests
    {
        private IngredientQuantityChecker _ingredientQuantityChecker = new IngredientQuantityChecker();
        private List<IDrink> _sampleDrinks;

        public IngredientQuantityCheckerTests()
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