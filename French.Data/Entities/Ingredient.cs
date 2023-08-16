using System.ComponentModel.DataAnnotations;

namespace French.Data.Entities;

public class Ingredient {
    [Key]
    public int IngredientId { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    [Required, MaxLength(1000)]
    public string Description { get; set; }

    //not implimented fully
    public virtual ICollection<Recipe> RecipeList { get; set; }

    public Ingredient() {
        RecipeList = new HashSet<Recipe>();
    } 
}
