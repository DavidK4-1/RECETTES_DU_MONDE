using System;
using French.Data.Entities;
using French.Models.Recipe;

namespace French.Models.UserFavoritesModels;

public class FavoritesListItem
{

    public int RecipeId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

}


