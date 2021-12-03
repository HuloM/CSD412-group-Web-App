using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookingBook.Models
{
    public class Instruction
    {
        [Key]
        public int InstructionID { get; set; }
        public int RecipeID { get; set; }

        [Required]
        public string InstructionText { get; set; }
    }
}
