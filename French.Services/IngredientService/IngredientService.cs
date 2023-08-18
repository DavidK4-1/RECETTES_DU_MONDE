using French.Data;
using French.Data.Entities;
using French.Models.IngredientModels;

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
        return new IngredientItem() {
            Description = Ingredient.Description,
            Name = Ingredient.Name
        };
    }
}
