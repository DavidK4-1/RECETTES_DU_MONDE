using Microsoft.AspNetCore.Identity;

namespace French.Data.Entities;

public class User : IdentityUser<int> {
    //comment before migrations for now
    public virtual UserFavorite UserFavoriteObj { get; set; }
}