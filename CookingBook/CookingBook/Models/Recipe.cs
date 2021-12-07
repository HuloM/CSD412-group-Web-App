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
        // user ID from AspNetUser table.
        public string? OwnerID { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Name { get; set; }

        [Display(Name = "Total Time (in minutes)")]
        [Range(1, 1000)]
        public int TotalTime { get; set; }

        public enum DifficultyType { Easy, Moderate, Difficult, Expert }

        public DifficultyType Difficulty { get; set; }


        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }


        [Required]
        [Display(Name ="Instructions")]
        public Instruction Instructions { get; set; }

        [Required]
        [Display(Name = "Ingredients")]
        public Ingredient Ingredients { get; set; }


    }
}
