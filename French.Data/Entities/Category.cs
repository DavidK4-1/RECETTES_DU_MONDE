using System.ComponentModel.DataAnnotations;

namespace French.Data.Entities;

public class Category
{
    [Key]
    public int CategoryId { get; set; } // Key

    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Recipe> ListOfRecipes { get; set; }

    public Category()
    {
        ListOfRecipes = new HashSet<Recipe>();
    }

}
