using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;

namespace French.Data.Entities;

public class UserFavorite
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("UserObj")]
    public int UserId { get; set; }

    public virtual User UserObj { get; set; } 

    public virtual ICollection<Recipe> ListOfRecipes { get; set; }

    public UserFavorite()
    {
        ListOfRecipes = new HashSet<Recipe>();
    }
}
