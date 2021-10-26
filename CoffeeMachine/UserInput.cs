using System;

namespace CoffeeMachine
{
    public class UserInput : IUserInput
    {
        public string GetUserResponse()
        {
            return Console.ReadLine();
        }

        public bool GetUserDecision()
        {
            string decision = Console.ReadLine();
            return decision == "y";
        }
    }
}