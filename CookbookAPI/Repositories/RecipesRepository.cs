using CookbookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookbookAPI.Repositories
{
    public class RecipesRepository : IRecipesRepository
    {

        public async Task AddRecipe(string name, string description, string imagePath)
        {
            var recipe = new Recipe() { Name = name, Description = description, ImagePath = imagePath };
            //context.Add & SaveAsync
        }

        public Recipe GetRecipe(int recipeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            throw new NotImplementedException();
        }
        public async Task AddIngredientForRecipe(int recipeId, string name, int amount, string unit)
        {
            var ingredient = new Ingredient() { Name = name, Amount = amount, Unit = unit };
            //Find recipe and add ingredient to context
        }
    }
}
