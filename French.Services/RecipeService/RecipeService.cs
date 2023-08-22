using System.ComponentModel;
using Azure.Core;
using French.Data;
using French.Data.Entities;
using French.Models.Recipe;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace French.Services.Recipe;

public class RecipeService : IRecipeService
{
    private readonly ApplicationDbContext _dbContext;

    public RecipeService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<RecipeListItems?>> GetAllRecipesAsync()
    {
        List<RecipeListItems> recipes = await _dbContext.Recipes
            .Select(entity => new RecipeListItems
            {
                ListOfCategorys = entity.ListOfCategorys,
                RecipeId = entity.RecipeId,
                Title = entity.Title,
                Description = entity.Description
            })
            .ToListAsync();

        return recipes;
    }

    public async Task<bool> CreateRecipeAsync(RecipeCreate request)

    {
        French.Data.Entities.Recipe entity = new()
        {
            Title = request.Title,
            Description = request.Description,
            Instruction = request.Instruction
        };

        _dbContext.Recipes.Add(entity);
        var numberOfChanges = await _dbContext.SaveChangesAsync();

        // Loop through 

        if (numberOfChanges != 1)
            return false;

        var recipe = _dbContext.Recipes.Entry(entity);

        foreach (var i in request.IngredientKeys)
        {
            var ingredient = await _dbContext.Ingredients.FindAsync(i);

            if (ingredient is not null)
                recipe.Entity.Ingredients.Add(ingredient);
        }

        numberOfChanges = await _dbContext.SaveChangesAsync();

        if (numberOfChanges != 1)
            return false;

        return true;
    }


    public async Task<List<RecipeListItems?>> GetRecipesByCategoryIdAsync(int categoryId)
    {
        if (categoryId == 0)
            return null;

        var recipes = await GetAllRecipesAsync();

        // Create a return list
        // Loop through every recipe to see if it has a match for a CategoryId
        //      if CategoryId appear in ListOfCategorys for current item we will add it to our return list
        // Return return list

        List<RecipeListItems> recipesList = new List<RecipeListItems>();

        foreach (var recipeItem in recipes)
        {
            foreach (var categoryItem in recipeItem!.ListOfCategorys)
            {
                if (categoryItem.CategoryId == categoryId)
                    recipesList.Add(recipeItem);
            }
        }
        return recipesList;
    }

    public async Task<bool> DeleteRecipeAsync(int recipeId)
    {
        var recipe = await _dbContext.Recipes.FindAsync(recipeId);

        if (recipe?.RecipeId != recipeId)
            return false;

        _dbContext.Recipes.Remove(recipe);
        return await _dbContext.SaveChangesAsync() == 1;
    }

    public async Task<List<RecipeDetail>> GetRecipesByIngredientIdAsync(int id)
    {
        List<RecipeDetail> ret = new();
        _dbContext.Categories.Load();
        foreach (var recipe in _dbContext.Recipes)
        {
            
            foreach (var item in recipe.Ingredients)
            {
                if (item.IngredientId == id)
                {

                    ret.Add(new RecipeDetail()
                    {
                        Instruction = recipe.Instruction,
                        Title = recipe.Title,
                        Description = recipe.Description,
                        RecipeId = recipe.RecipeId
                    });
                    break;
                }
            }
        }

        return ret;
    }

    public async Task<RecipeDetail?> GetRecipeByRecipeIdAsync(int recipeId)
    {
        var recipe = await _dbContext.Recipes
            .FirstOrDefaultAsync(r =>
                r.RecipeId == recipeId);

        return recipe is null
        ? null
        : new RecipeDetail
        {
            RecipeId = recipe.RecipeId,
            Title = recipe.Title,
            Description = recipe.Description,
            Instruction = recipe.Instruction,
            ListOfIngredients = (ICollection<Ingredient>)recipe.ListOfIngredients
        };

    }

}
