using CookbookAPI.Data;
using CookbookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookbookAPI.Repositories
{
    public class RecipesRepository : IRecipesRepository
    {
        private CookbookDbContext cookbookDbContext;
        public RecipesRepository(CookbookDbContext _context)
        {
            cookbookDbContext = _context;
        }

        public async Task AddRecipe(string name, string description, string imagePath)
        {
            var recipe = new Recipe() { Name = name, Description = description, ImagePath = imagePath };
            cookbookDbContext.Recipes.Add(recipe);
            await cookbookDbContext.SaveChangesAsync();
        }

        public Recipe GetRecipe(int recipeId)
        {
            return cookbookDbContext.Recipes.FirstOrDefault(recipe => recipe.Id == recipeId);
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return cookbookDbContext.Recipes.ToList();
        }

        public async Task AddIngredientForRecipe(int recipeId, string name, int amount, string unit)
        {
            var ingredient = new Ingredient() { Name = name, Amount = amount, Unit = unit };
            var recipe = cookbookDbContext.Recipes.FirstOrDefault(recipe => recipe.Id == recipeId);
            if (recipe != null)
            {
                recipe.Ingredients.Add(ingredient);
                cookbookDbContext.Recipes.Update(recipe);
                await cookbookDbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<Ingredient> GetIngredientsForRecipe(int recipeId)
        {
            return cookbookDbContext.Ingredients.Where(ingredient => ingredient.RecipeId == recipeId).ToList();
        }

        public async Task RemoveRecipe(int id)
        {
            var recipe = cookbookDbContext.Recipes.FirstOrDefault(recipe => recipe.Id == id);
            if (recipe != null)
            {
                cookbookDbContext.Recipes.Remove(recipe);
                await cookbookDbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveIngredient(int recipeId, int ingredientId)
        {
            var ingredient = cookbookDbContext.Ingredients.FirstOrDefault(ingredient => ingredient.Id == ingredientId);
            if (ingredient != null)
            {
                cookbookDbContext.Ingredients.Remove(ingredient);
                await cookbookDbContext.SaveChangesAsync();
            }   
        }
    }
}
