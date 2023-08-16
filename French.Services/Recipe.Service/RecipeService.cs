using French.Data;
using French.Data.Entities;
using French.Models.RecipeModels;
using Microsoft.AspNetCore.Identity;


namespace French.Services.Recipe;

    public class RecipeService : IRecipeService
    {
       private readonly ApplicationDbContext _dbContext;

       public RecipeService(ApplicationDbContext dbContext)
       {
            _dbContext = dbContext;
       }

public Task<bool> CreateRecipe(RecipeCreate request)
    {
        throw new NotImplementedException();
    }
}
