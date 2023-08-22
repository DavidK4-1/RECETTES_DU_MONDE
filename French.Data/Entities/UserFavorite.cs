using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD

=======
>>>>>>> 5913ab396e401f0f66b674ae46aadeeec05605cf
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
