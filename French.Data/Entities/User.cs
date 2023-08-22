using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace French.Data.Entities;

public class User : IdentityUser<int> {
    //comment before migrations for now

    public virtual UserFavorite UserFavorite { get; set; }
}