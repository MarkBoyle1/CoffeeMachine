using System;

namespace CoffeeMachine
{
    public class UserInput : IUserInput
    {
        public string GetUserResponse()
        {
            return Console.ReadLine();
        }

        public string GetUserDecision()
        {
            return Console.ReadLine();
        }
    }
}