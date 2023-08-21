using System;
using French.Models.UserFavoritesModels;

namespace French.Services.UserFavoritesService
{
	public interface IUserFavoritesService
	{
	
        Task<List<French.Data.Entities.Recipe>> GetAllFavoritesAsync();

        Task<bool> AddRecipeToFavoritesAsync(int recipeId);

        //Add User Id
        Task<bool> CreateUserFavoriteAsync();

        Task<bool> DeleteUserFavoriteAsync(int FavorieId);

    }
}

