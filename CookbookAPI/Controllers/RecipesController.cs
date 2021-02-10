using CookbookAPI.Models;
using CookbookAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookbookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IEnumerable<Recipe> GetRecipes()
        {
            return recipesRepository.GetRecipes();
        }

        public Recipe GetRecipeById(int id)
        {
            return recipesRepository.GetRecipe(id);
        }

        [HttpPost]
        public async Task AddRecipe(string name, string description, string imagePath)
        {
            await recipesRepository.AddRecipe(name, description, imagePath);
        }

        public async Task AddIngredientToRecipe(int recipeId, string name, int amount, string unit)
        {
            recipesRepository.AddIngredientForRecipe(recipeId, name, amount, unit);
        }
    }
}
