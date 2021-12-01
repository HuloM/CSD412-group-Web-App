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

        [Theory]
        [InlineData(1, 3, "Mint")]
        public void IngredientTest2(int IngredientID, int RecipeID, string ingredientString)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.IngredientID = IngredientID;
            ingredient.RecipeID = RecipeID;
            ingredient.ingredient = ingredientString;

            Assert.Equal(1, ingredient.IngredientID);
            Assert.Equal(3, ingredient.RecipeID);
            Assert.Equal("Mint", ingredient.ingredient);
        }

    }
}
