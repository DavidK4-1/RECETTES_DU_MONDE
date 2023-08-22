using French.Models.IngredientModels;
using French.Models.Recipe;

namespace French.Services.IngredientService;

public interface IIngredientService {
    Task<bool> CreateIngredientAsync(CreateIngredient model);
    Task<IngredientItem?> GetIngredientByIdAsync(int id);
    Task<IEnumerable<IngredientItem>> GetAllIngredientItemsAsync();
}
