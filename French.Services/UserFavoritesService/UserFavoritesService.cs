using System;
using French.Data;
using French.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace French.Services.UserFavoritesService
{
	public class UserFavoritesService : IUserFavoriteService
	{
		private readonly ApplicationDbContext _context;
		
		public UserFavoritesService(ApplicationDbContext context)
		{
			_context = context;
		}

		public void AddRecipeToFavorites(int recipeId, int userId)
		{
			UserFavorite favorite = new UserFavorite()
			{
				UserId = userId,
				RecipeId = recipeId
			};

			_context.UserFavorites.Add(favorite);
			_context.SaveChangesAsync();
		}
	}
}

