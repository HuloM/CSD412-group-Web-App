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

        [Fact]
        public void RecipeFactTest()
        {
            Recipe recipe = new Recipe();
            recipe.RecipeID = 1;
            recipe.Name = "Cheese cake";
            recipe.TotalTime = 60;
            recipe.Difficulty = Recipe.DifficultyType.Moderate;
            recipe.DateCreated = new DateTime(2021, 12, 05);
            Instruction instruction = new Instruction() { InstructionID = 1, RecipeID = 3, InstructionText = "Put in Oven" };
            Ingredient ingredient = new Ingredient() { IngredientID = 1, RecipeID = 3, ingredient = "Cheese" };
            recipe.Instructions = instruction;
            recipe.Ingredients = ingredient;

            Assert.Equal(1, recipe.RecipeID);
            Assert.Equal("Cheese cake", recipe.Name);
            Assert.Equal(60, recipe.TotalTime);
            Assert.Equal(Recipe.DifficultyType.Moderate, recipe.Difficulty);
            Assert.Equal(new DateTime(2021, 12, 05), recipe.DateCreated);
            Assert.Equal(instruction, recipe.Instructions);
            Assert.Equal(ingredient, recipe.Ingredients);
        }

    }
}
