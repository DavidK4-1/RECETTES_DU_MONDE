using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace French.Data.Entities;

public class UserFavorite
{
    public int userFavoriteId { get; set; }  // key

    public int recipeId { get; set; } // foreign key

    public int userId { get; set; } // foreign key
}
