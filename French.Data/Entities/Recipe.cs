using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace French.Data.Entities;

public class Recipe
{
    [Key]
    public int RecipeId { get; set; }

    [Required, MinLength(1), MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required, MinLength(1), MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    [Required, MinLength(1), MaxLength(8000)]
    public string Instruction { get; set; } = string.Empty;

    [ForeignKey(nameof(Ingredients))]
    public int IngredientId { get; set; }
    public virtual List<Ingredient> Ingredients { get; set; } = null!;

    [ForeignKey(nameof(Catagory))]
    public int CatagoryId { get; set; }
    public virtual Catagory Catagory { get; set; } = null!;

}
