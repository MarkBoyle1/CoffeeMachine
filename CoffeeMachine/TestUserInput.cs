using System;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class TestUserInput : IUserInput
    {
        private List<string> _listOfResponses;
        private List<string> _listOfDecisions;

            
            public TestUserInput(List<string> listOfResponses, List<string> listOfDecisions)
            {
                _listOfResponses = listOfResponses;
                _listOfDecisions = listOfDecisions;
            }
            
            public string GetUserResponse()
            {
                string response = _listOfResponses[0];
                _listOfResponses.RemoveAt(0);
            
                return response;
            }

            public bool GetUserDecision()
            {
                string decision = _listOfDecisions[0];
                _listOfDecisions.RemoveAt(0);
            
                return decision == "y";
            }
    }
}