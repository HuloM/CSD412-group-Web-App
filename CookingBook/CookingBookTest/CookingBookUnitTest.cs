using System;
using Xunit;
using CookingBook.Models;

namespace CookingBookTest
{
    public class CookingBookUnitTest
    {
        [Fact]
        public void IngredientTest1()
        {
            Ingredient ingredient = new Ingredient();
            ingredient.IngredientID = 1;
            ingredient.RecipeID = 3;
            ingredient.ingredient = "Mint";

            Assert.Equal(1, ingredient.IngredientID);
            Assert.Equal(3, ingredient.RecipeID);
            Assert.Equal("Mint", ingredient.ingredient);
        }
    }
}
