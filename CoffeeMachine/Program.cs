using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachineEngine _coffeeMachineEngine = new CoffeeMachineEngine();
            _coffeeMachineEngine.CreateOrder("T:1:");
        }
    }
}