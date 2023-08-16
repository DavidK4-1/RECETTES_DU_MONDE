using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace French.Data.Entities;

public class UserFavorite
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("UserFavoriteId")]
    public int UserId { get; set; }

    public virtual User UserFavoriteId { get; set; } 

    [ForeignKey("Recipe")]
    public int RecipeId { get; set; }

    public virtual Recipe Recipe { get; set; }


    //public virtual ICollection<Recipe> ListOfRecipes { get; set; }

    //public UserFavorite()
    //{
    //    ListOfRecipes = new HashSet<Recipe>();
    //}
}
