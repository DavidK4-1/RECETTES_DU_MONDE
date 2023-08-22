using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD

=======
>>>>>>> 5913ab396e401f0f66b674ae46aadeeec05605cf
using System.ComponentModel.DataAnnotations.Schema;

namespace French.Data.Entities;

public class UserFavorite
{
    [Key]
    public int FavoriteId { get; set; }

    [ForeignKey("UserObj")]
    public int UserId { get; set; }

    public virtual User UserObj { get; set; }

    public virtual ICollection<Recipe> ListOfRecipes { get; set; } = null!;

    public UserFavorite()
    {
        ListOfRecipes = new HashSet<Recipe>();
    }
}
