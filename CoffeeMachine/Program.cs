using System;
using System.Collections.Generic;
using CoffeeMachine.Drinks;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachineEngine _coffeeMachineEngine = new CoffeeMachineEngine(new UserInput());
            _coffeeMachineEngine.RunProgram();
        }
    }
}