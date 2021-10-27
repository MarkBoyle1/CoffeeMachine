using System;

namespace CoffeeMachine.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string input)
            : base(String.Format("Invalid DrinkCode: {0}", input))
        {

        }
    }
}