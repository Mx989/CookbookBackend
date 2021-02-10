using CookbookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookbookAPI.Repositories
{
    public interface IRecipesRepository
    {
        public IEnumerable<Recipe> GetRecipes();
        public Recipe GetRecipe(int recipeId);
        public Task AddRecipe(string name, string description, string imagePath);
        public Task AddIngredientForRecipe(int recipeId, string name, int amount, string unit);
    }
}
