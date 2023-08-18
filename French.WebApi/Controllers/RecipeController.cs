using French.Data.Entities;
using French.Models.Recipe;
using French.Models.Responces;
using French.Services.Recipe;
using Microsoft.AspNetCore.Mvc;

namespace French.WebApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            var recipes = await _recipeService.GetAllRecipesAsync();
            return Ok(recipes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromBody] RecipeCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _recipeService.CreateRecipeAsync(request);
            if (response)
                return Ok(Response);

            return BadRequest(new TextResponse("Could not create Recipe"));
        }

        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> GetRecipeByCategoryId([FromRoute] int categoryId)
        {
            var detail = await _recipeService.GetRecipesByCategoryIdAsync(categoryId);
            return detail is not null
                ? Ok(detail)
                : NotFound();
        }

        [HttpDelete("{recipeId:int}")]
        public async Task<IActionResult> DeleteRecipe([FromRoute] int recipeId)
        {
            return await _recipeService.DeleteRecipeAsync(recipeId)
                ? Ok($"Recipe {recipeId} was deleted successfully.")
                : BadRequest($"Recipe {recipeId} could not be deleted.");
        }
        
    }
