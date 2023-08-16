using French.Models.IngredientModels;

namespace French.Services.IngredientService;

public interface IIngredientService {
    Task<bool> CreateIngredientAsync(CreateIngredient model);
    Task<IngredientItem?> GetIngredientByIdAsync(int id);
}
