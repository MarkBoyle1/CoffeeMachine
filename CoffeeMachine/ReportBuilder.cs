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
                foreach (Message message in order.ItemList)
                {
                    string itemType = message.itemType;
                    if (itemType != "Message")
                    {
                        sales[itemType] = sales.ContainsKey(itemType) ? sales[itemType] + 1 : 1;
                    }

                    // sales.TryAdd(drinkType, 1) && sales[drinkType]++;
                    // if (!sales.TryAdd(itemType, 1))
                    // {
                    //     sales[itemType] = sales[itemType] + 1;
                    // }
                    
                    
                    totalRevenue += message.value;
                }
            }

            sales["Total Revenue"] = totalRevenue;
            return new Report(sales);
        }
    }
}