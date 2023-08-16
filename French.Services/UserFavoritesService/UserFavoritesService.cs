using System;
using French.Data;
using French.Data.Entities;
namespace French.Services.UserFavoritesService
{
	public class UserFavoritesService : IUserFavoriteService
	{
		public void AddRecipeToFavorites(int recipeId, int userId)
		{
            using (var ctx = new ApplicationDbContext())
			{
				var foundRecipe = ctx.Recipes.Single(f => f.recipeId == recipeId);
				var foundUser = ctx.Users.Single(o => o.Id == userId);
				foundRecipe.ListOfFavorites.Add(foundFavorite)

			}
		}
	}
}

