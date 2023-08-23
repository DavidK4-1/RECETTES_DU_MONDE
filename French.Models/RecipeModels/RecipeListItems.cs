using French.Data.Entities;
using French.Models.IngredientModels;

namespace French.Models.Recipe;

public class RecipeListItems
{
    public int RecipeId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public IngredientItem [] Ingredients { get; set; } = null!; //Maybe remove 

    //public Category [] Categorys { get; set; } = null!;


}
