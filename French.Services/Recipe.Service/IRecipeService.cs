using French.Models.RecipeModels;

namespace French.Services.Recipe;

public interface IRecipeService
{
    Task<IEnumerable<RecipeDetails>> GetAllRecipesAsync();
    
}