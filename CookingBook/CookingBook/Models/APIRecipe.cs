using System;
using System.ComponentModel.DataAnnotations;

namespace CookingBook.Models
{
    public class APIRecipe
    {
        public string Name { get; set; }
        public int TotalTime { get; set; }
        public enum DifficultyType { Easy, Moderate, Difficult, Expert } 

        public DifficultyType Difficulty { get; set; }
        public DateTime DateCreated { get; set; }

        [Display(Name = "Instructions")]
        public Instruction Instructions { get; set; }

        [Display(Name = "Ingredients")]
        public Ingredient Ingredients { get; set; }

        public string VideoString { get; set; }
    }
}
