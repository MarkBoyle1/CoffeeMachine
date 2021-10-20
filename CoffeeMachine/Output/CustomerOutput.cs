using System;
using CoffeeMachine.Output;

namespace CoffeeMachine
{
    public class CustomerOutput : IOutput
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}