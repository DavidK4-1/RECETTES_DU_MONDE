using System;
using French.Models.UserFavoritesModels;

namespace French.Services.UserFavoritesService
{
	public interface IUserFavoritesService
	{
		Task<IEnumerable<FavoritesListItem>> GetAllFavoritesAsync();

		//Task<FavoritesListItem?> AddRecipeToFavoritesAsync(int recipeId, int userId);
	}
}

