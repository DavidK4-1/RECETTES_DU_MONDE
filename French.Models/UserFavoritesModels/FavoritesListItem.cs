using System;
using French.Data.Entities;
using French.Models.Recipe;

namespace French.Models.UserFavoritesModels;

public class FavoritesListItem
{
	public int Id { get; set; }

    public ICollection<RecipeDetail> ListOfRecipes { get; set; } = null!;

 // public RecipeDetail ListOfRecipes { get; set; } = null!;
}


