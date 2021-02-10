using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookbookAPI.Models
{
    public class Ingredient
    {
        [Required]
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int RecipeId { get; set; }

        [Required]
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
    }
}
