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

/*
    public async Task<FavoritesListItem> CreateUserFavoriteAsync()
    {
        UserFavorite favorite = new()
        {
            UserId = _userId,
        };

        _context.UserFavorites.Add(favorite);
        var nuberOfChanges = await _context.SaveChangesAsync();
    }
*/
    public async Task<bool> CreateUserFavoriteAsync()
    {
        UserFavorite favorite = new()
        {
            UserId = _userId,
        };

        _context.UserFavorites.Add(favorite);
        return await _context.SaveChangesAsync() == 1;

    }
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

 // public void AddRecipeToFavorites(int _userId)
}


