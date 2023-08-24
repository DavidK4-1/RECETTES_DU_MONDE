using French.Data;
using French.Data.Entities;
using French.Models.IngredientModels;
using French.Models.Recipe;
using Microsoft.EntityFrameworkCore;

namespace French.Services.IngredientService;

public class IngredientService : IIngredientService{
    private readonly ApplicationDbContext _context;

    public IngredientService(ApplicationDbContext context) {
        _context = context;
    }

    public async Task<bool> CreateIngredientAsync(CreateIngredient model) {
        Ingredient ingredient = new() {
            Name = model.Name,
            Description = model.Description
        };
        
        _context.Ingredients.Add(ingredient);
        return await _context.SaveChangesAsync() == 1;
    }
    public async Task<IngredientItem?> GetIngredientByIdAsync(int id) {
        var Ingredient = await _context.Ingredients.FindAsync(id);

        if (Ingredient is null) 
            return null;
        return new IngredientItem() {
            Description = Ingredient.Description,
            Name = Ingredient.Name,
            Id = Ingredient.IngredientId
        };
    }
    /*
    //does this go in the recipe controller
    public async Task<List<RecipeDetail>> GetRecipeByIngredientIdAsync(int id) {
        //i know there is an easier way to do it but i dont care
        List<RecipeDetail> ret = new();
        foreach (var recipe in _context.Recipes)
            foreach (var item in recipe.Ingredients)
                if (item.IngredientId == id) {
                    ret.Add(new RecipeDetail() {
                        Instruction = recipe.Instruction,
                        Title = recipe.Title,
                        Description = recipe.Description,
                        RecipeId = recipe.RecipeId
                    });
                    break;
                }

        return ret;
    }
    */
    public async Task<IEnumerable<IngredientItem>> GetAllIngredientItemsAsync()
        => await _context.Ingredients.Select(x => new IngredientItem() { Description = x.Description,
                                                                         Name = x.Name,
                                                                         Id = x.IngredientId
                                                                       }).ToListAsync();
}
