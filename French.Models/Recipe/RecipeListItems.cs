using French.Data.Entities;
namespace French.Models.Recipe;

public class RecipeListItems
{
    public int RecipeId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public ICollection<French.Data.Entities.Category> ListOfCategorys { get; set; } = null!;

    public Ingredient [] Ingredients { get; set; } = null!;

    public Category [] Categorys { get; set; } = null!;


}
