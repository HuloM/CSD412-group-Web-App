using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookingBook.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientID { get; set; }
        public int RecipeID { get; set; }
        [Required]
        public string ingredient { get; set; }
    }
}
