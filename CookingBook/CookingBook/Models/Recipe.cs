using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CookingBook.Models
{
    public class Recipe
    {
        [Key]//primary key
        public int RecipeID { get; set; }
       // [Required]
        public string Name { get; set; }
        public int TotalTime { get; set; } //optional
        public enum DifficultyType { Easy, Moderate, Difficult, Expert } //optional
        public DifficultyType Difficulty { get; set; }
        public DateTime DateCreated { get; set; }//optional


        //[Required]
        [Display(Name ="Instructions")]
        public Instruction Instructions { get; set; }

        //[Required]
        [Display(Name = "Ingredients")]
        public Ingredient Ingredients { get; set; } //needs to be a collection 


    }
}
