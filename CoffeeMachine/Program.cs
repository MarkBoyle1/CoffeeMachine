using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachineEngine _coffeeMachineEngine = new CoffeeMachineEngine();
            _coffeeMachineEngine.CreateMessage("O::", "T::", "C:1:0", "L;;", "9.6");
        }
    }
}