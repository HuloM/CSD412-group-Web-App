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
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public IEnumerable<Instruction> Instructions { get; set; }
        [Required]
        public IEnumerable<Ingredient> Ingredients { get; set; } //needs to be a collection 
        public int TotalTime { get; set; } //optional
<<<<<<< Updated upstream
        public enum DifficultyType { Easy, Moderate, Difficult, Expert } //optional
=======
        public enum DifficultyType
        {
            //[Display(Name = "Easy")]
            Easy,
            //[Display(Name = "Moderate")]
            Moderate,
            //[Display(Name = "difficult")]
            Difficult,
            //[Display(Name = "Expert")]
            Expert
        } //optional
        //[EnumDataType(typeof(DifficultyType)), Display(Name = "Difficulty")]
>>>>>>> Stashed changes
        public DifficultyType Difficulty { get; set; }
        public DateTime DateCreated { get; set; }//optional


    }
<<<<<<< Updated upstream
=======
    
>>>>>>> Stashed changes
}
