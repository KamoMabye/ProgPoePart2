using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace POEUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void calculateTotalCalories()
        {
            Recipe recipe = new Recipe();
            Ingredient ingredient1 = new Ingredient("Sugar", 1, "tablespoon", 50, "Fats and Oils");
            Ingredient ingredient2 = new Ingredient("Flour", 2, "cups", 300, "Starchy Foods");
            recipe.Ingredients.Add(ingredient1);
            recipe.Ingredients.Add(ingredient2);

            // Act
            int totalCal = recipe.totalCalories();

            // Assert
            Assert.AreEqual(350, totalCal);
        }
    }
}
