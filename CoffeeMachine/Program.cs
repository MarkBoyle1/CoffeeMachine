using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachineEngine _coffeeMachineEngine = new CoffeeMachineEngine();
            Console.WriteLine(_coffeeMachineEngine.CreateOrder("T::"));
        }
    }
}