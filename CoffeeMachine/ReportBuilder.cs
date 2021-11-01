using System;
using System.Collections.Generic;
using CoffeeMachine.Output;

namespace CoffeeMachine
{
    public class ReportBuilder
    {
        public Report CreateReport(List<Order> orders)
        {
            Dictionary<string, double> sales = new Dictionary<string, double>();
            double totalRevenue = 0;

            foreach (Order order in orders)
            {
                if (order.PossibleToMake)
                {
                    foreach (IDrink drink in order.DrinkList)
                    {
                        string drinkType = drink.GetDrinkType();
                        sales[drinkType] = sales.ContainsKey(drinkType) ? sales[drinkType] + 1 : 1;
                    

                        totalRevenue += drink.GetPrice();
                    }
                }
                
            }

            sales["Total Revenue"] = Math.Round(totalRevenue, 1);
            return new Report(sales);
        }
    }
}