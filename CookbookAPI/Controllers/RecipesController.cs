using CookbookAPI.Models;
using CookbookAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookbookAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly ILogger<RecipesController> logger;
        private IRecipesRepository recipesRepository;

        public RecipesController(IRecipesRepository _recipesRepository, ILogger<RecipesController> _logger)
        {
            recipesRepository = _recipesRepository;
            logger = _logger;
        }

        [HttpGet]
        [Route("GetRecipes")]
        public IEnumerable<Recipe> GetRecipes()
        {
            return recipesRepository.GetRecipes();
        }

        public Recipe GetRecipeById(int id)
        {
            return recipesRepository.GetRecipe(id);
        }

        [Route("GetIngredients")]
        public IEnumerable<Ingredient> GetIngredientsForRecipe(int recipeId)
        {
            return recipesRepository.GetIngredientsForRecipe(recipeId);
        }

        [Route("RemoveRecipe")]
        public async Task RemoveRecipe(int id)
        {
            await recipesRepository.RemoveRecipe(id);
        }
                
        [Route("RemoveIngredient")]
        public async Task RemoveIngredient(int recipeId, int ingredientId)
        {
            await recipesRepository.RemoveIngredient(recipeId, ingredientId);
        }

        [HttpPost]
        [Route("AddRecipe")]
        public async Task AddRecipe(string name, string description, string imagePath)
        {
            await recipesRepository.AddRecipe(name, description, imagePath);
        }

        [Route("AddIngredient")]
        public async Task AddIngredientToRecipe(int recipeId, string name, int amount, string unit)
        {
            await recipesRepository.AddIngredientForRecipe(recipeId, name, amount, unit);
        }
    }
}
