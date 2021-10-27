using System.Collections.Generic;

namespace CoffeeMachine
{
    public class Report
    {
        public Dictionary<string, double> _results { get; }

        public Report(Dictionary<string,double> results)
        {
            _results = results;
        }
    }
}