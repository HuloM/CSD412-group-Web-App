using System;
using Xunit;
using CookingBook.Models;

namespace CookingBookTest
{
    public class CookingBookUnitTest
    {
        [Fact]
        public void IngredientFactTest()
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
        public void IngredientTheoryTest(int ingredientID, int recipeID, string ingredientString)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.IngredientID = ingredientID;
            ingredient.RecipeID = recipeID;
            ingredient.ingredient = ingredientString;

            Assert.Equal(1, ingredient.IngredientID);
            Assert.Equal(3, ingredient.RecipeID);
            Assert.Equal("Mint", ingredient.ingredient);
        }

        [Fact]
        public void InstructionFactTest()
        {
            Instruction instruction = new Instruction();
            instruction.InstructionID = 1;
            instruction.RecipeID = 3;
            instruction.InstructionText = "Add one tea spoon";

            Assert.Equal(1, instruction.InstructionID);
            Assert.Equal(3, instruction.RecipeID);
            Assert.Equal("Add one tea spoon", instruction.InstructionText);
        }

        [Theory]
        [InlineData(1, 3, "Add one tea spoon")]
        public void InstructionTheoryTest(int instructionID, int recipeID, string instructionString)
        {
            Instruction instruction = new Instruction();
            instruction.InstructionID = instructionID;
            instruction.RecipeID = recipeID;
            instruction.InstructionText = instructionString;

            Assert.Equal(1, instruction.InstructionID);
            Assert.Equal(3, instruction.RecipeID);
            Assert.Equal("Add one tea spoon", instruction.InstructionText);
        }

    }
}
