using System;
using System.Collections.Generic;
using CoffeeMachine.Ingredients;
using Enum = System.Enum;

namespace CoffeeMachine
{
    public interface IDrink
    {
        string GetDrinkType();
        
        string GetSugarAmount();

        double GetPrice();

        DrinkTemperature GetDrinkTemperature();

        List<IIngredient> GetIngredientList();

    }
}