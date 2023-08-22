using System;
using French.Models.UserFavoritesModels;

namespace French.Services.UserFavoritesService
{
	public interface IUserFavoritesService
	{
		Task<IEnumerable<FavoritesListItem>> GetAllFavoritesAsync();

        Task<bool> AddRecipeToFavoritesAsync(int FavoriteId, int recipeId);

        //Add User Id
         Task<bool> CreateUserFavoriteAsync();

    }
}

