using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace French.Data.Entities;

public class Recipe
{
    public virtual ICollection<Category> ListOfCategories { get; set; }

    public virtual ICollection<UserFavorite> ListOfFavorites { get; set; }

    public Recipe()
    {
        ListOfFavorites = new HashSet<UserFavorite>();
        ListOfCategories = new HashSet<Category>();
    }
}
