using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachineEngine _coffeeMachineEngine = new CoffeeMachineEngine();
            _coffeeMachineEngine.CreateMessage("T::", "O::", "O::", "O::", "T::", "T::", "T::", "9.6");
        }
    }
}