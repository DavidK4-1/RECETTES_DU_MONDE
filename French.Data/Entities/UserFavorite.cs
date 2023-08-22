using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace French.Data.Entities;

//[Keyless]
public class UserFavorite
{
 //   [Key]
//    public int FavoriteId { get; set; }

    [Key, ForeignKey("User")]
    public int UserId { get; set; }

    public virtual User User { get; set; }

    public virtual ICollection<Recipe> ListOfRecipes { get; set; } = null!;

    public UserFavorite()
    {
        ListOfRecipes = new HashSet<Recipe>();
    }
}
