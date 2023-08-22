using French.Models.Recipe;
using French.Services;
using Microsoft.EntityFrameworkCore;

namespace French.Services.Recipe;

public interface IRecipeService
{
    Task<IEnumerable<RecipeListItems?>> GetAllRecipesAsync();
    Task<bool> CreateRecipeAsync(RecipeCreate request);
    Task<List<RecipeListItems?>> GetRecipesByCategoryIdAsync(int categoryId);
    Task<bool> DeleteRecipeAsync(int recipeId);
    Task<List<RecipeDetail?>> GetRecipesByIngredientIdAsync(int id);
}