using System.Collections.Generic;
using CoffeeMachine.Ingredients;

namespace CoffeeMachine
{
    public interface IEmailNotifier
    {
        void notifyMissingIngredients(List<IIngredient> missingIngredients);
    }
}