using System.Collections.Generic;
using CoffeeMachine.Ingredients;
using CoffeeMachine.Output;

namespace CoffeeMachine
{
    public class EmailNotifier : IEmailNotifier
    {
        private IOutput _output;

        public EmailNotifier()
        {
            _output = new CustomerOutput();
        }
        
        public void notifyMissingIngredients(List<IIngredient> missingIngredients)
        {
            _output.DisplayMessage(OutputMessages.OrderNotPossible);
            foreach (var ingredient in missingIngredients)
            {
                _output.DisplayMessage(ingredient.GetIngredientName());
            }
            
            _output.DisplayMessage(OutputMessages.SendingEmailNotification);
        }
    }
}