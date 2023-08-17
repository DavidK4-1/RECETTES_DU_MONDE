using French.Data;
using French.Data.Entities;
using French.Models.UserFavoritesModels;
using Microsoft.EntityFrameworkCore;

namespace French.Services.UserFavoritesService
{
	public class UserFavoritesService : IUserFavoritesService
	{
		private readonly ApplicationDbContext _context;
		private readonly int _userId;
		
		public UserFavoritesService(ApplicationDbContext context)
		{
			_context = context;
		}
		/*
        public void AddRecipeToFavoritesAsync(int recipeId, int userId)
		{
            UserFavorite favorite = new()
			{
				UserId = userId,
				RecipeId = recipeId
			};

			_context.UserFavorites.Add(favorite);
			_context.SaveChangesAsync();
		}
		*/
        public async Task<IEnumerable<FavoritesListItem>> GetAllFavoritesAsync()
		{
			List<FavoritesListItem> favorites = await _context.UserFavorites
				.Where(entity => entity.Id == _userId)
				.Select(entity => new FavoritesListItem
				{
					Id = entity.Id
				})
				.ToListAsync();

			return favorites;
		}
	}
}

