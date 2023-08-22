using French.Data;
using French.Data.Entities;
using French.Models.UserFavoritesModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace French.Services.UserFavoritesService;

public class UserFavoritesService : IUserFavoritesService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager; // Tokens Required
    private readonly SignInManager<User> _signInManager;
    private readonly int _userId;

    public UserFavoritesService(ApplicationDbContext context,
                                UserManager<User> userManager,
                                SignInManager<User> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;

        var currUser = signInManager.Context.User;
        if (currUser.Identity?.Name is not null)
        {
            //retreve an id if signed in (put it into a private field)
            var userIdClaim = userManager.GetUserId(currUser);
            if (!int.TryParse(userIdClaim, out _userId))
                throw new Exception("invalid id");
        }
    }

    public async Task<bool> CreateUserFavoriteAsync()
    {
        UserFavorite favorite = new()
        {
            FavoriteId = _userId,
        };

        _context.UserFavorites.Add(favorite);
        return await _context.SaveChangesAsync() == 1;

    }
    public async Task<IEnumerable<FavoritesListItem>> GetAllFavoritesAsync()
    {
        List<FavoritesListItem> favorites = await _context.UserFavorites
            .Where(entity => entity.FavoriteId == _userId)
            .Select(entity => new FavoritesListItem
            {
                Id = entity.FavoriteId
            })
            .ToListAsync();

        return favorites;
    }

    public async Task<bool> AddRecipeToFavoritesAsync(int favoriteId, int recipeId)
    {
        var favorite = await _context.UserFavorites.FindAsync(favoriteId);
        var recipe = await _context.Recipes.FindAsync(recipeId);
        favorite?.ListOfRecipes.Add(recipe);
        return await _context.SaveChangesAsync() == 1;

    }
}

