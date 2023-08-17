using French.Models.RecipeModels;
using Microsoft.EntityFrameworkCore;

namespace French.Services.Recipe;

public interface IRecipeService
{
    // Task<IEnumerable<RecipeDetails>> GetAllRecipesAsync();
    Task<bool> CreateRecipe(RecipeCreate request);
    
    
}