using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingBook.Models
{
    public class RecipeIndexData
    {
        public IEnumerable<Recipe> Recipes { get; set; }
        public IEnumerable<Instruction> Instructions { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
