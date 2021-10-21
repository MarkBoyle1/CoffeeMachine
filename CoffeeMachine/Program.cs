using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachineEngine _coffeeMachineEngine = new CoffeeMachineEngine();
            _coffeeMachineEngine.CreateMessage("O::", "Th::", "C:1:0", "9.6");
        }
    }
}