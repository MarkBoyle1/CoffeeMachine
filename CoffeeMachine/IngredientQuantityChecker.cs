using System.Collections.Generic;
using CoffeeMachine.Ingredients;


namespace CoffeeMachine
{
    public class IngredientQuantityChecker
    {
        public List<IIngredient> CheckForEmptyIngredients(Order order)
        {
            List<IIngredient> emptyIngredients = new List<IIngredient>();

            foreach (var drink in order.DrinkList)
            {
                List<IIngredient> ingredientList = drink.GetIngredientList();
                
                foreach (var ingredient in ingredientList)
                {
                    if (ingredient.isEmpty())
                    {
                        emptyIngredients.Add(ingredient);
                    }
                }
            }

            return emptyIngredients;
        }
    }
}