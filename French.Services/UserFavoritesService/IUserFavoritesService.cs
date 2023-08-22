using System;
using French.Models.Recipe;
using French.Models.UserFavoritesModels;

namespace French.Services.UserFavoritesService
{
	public interface IUserFavoritesService
	{
	
        Task<List<RecipeDetail>> GetAllUserFavoritesAsync();

        Task<bool> AddRecipeToFavoritesAsync(int recipeId);

        Task<bool> CreateUserFavoriteAsync();

    //  Task<bool> DeleteUserFavoriteAsync(int FavorieId);

    }
}

