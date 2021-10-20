using System;

namespace CoffeeMachine.Output
{
    public class DrinkMakerOutput : IOutput
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}