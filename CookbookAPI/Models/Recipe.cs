using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookbookAPI.Models
{
    public class Recipe
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public List<Ingredient>? Ingredients { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }
    }
}
