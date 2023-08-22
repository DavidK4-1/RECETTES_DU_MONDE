using System.Linq;
using French.Data;
using French.Data.Entities;
using French.Models.Recipe;
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
            UserId = _userId,
        };

        _context.UserFavorites.Add(favorite);

        var check = await _context.SaveChangesAsync();

        return check == 1;

    }

    public async Task<List<RecipeDetail>> GetAllUserFavoritesAsync()
    {
        var user = await _context.UserFavorites
            .Where(e => e.UserId == _userId)
            .Include(l => l.ListOfRecipes)
            .ToListAsync();

        var returnList = new List<RecipeDetail>();

        foreach (var recipe in user[0].ListOfRecipes)
        {
            RecipeDetail entry = new()
            {
                RecipeId = recipe.RecipeId,
                Title = recipe.Title,
                Description = recipe.Description,
                Instruction = recipe.Instruction
            };
            returnList.Add(entry);
        }
        return returnList;
    }

    public async Task<bool> AddRecipeToFavoritesAsync(int recipeId)
    {
        var userfavorite = await _context.UserFavorites.FindAsync(_userId);
        var recipe = await _context.Recipes.FindAsync(recipeId);
        userfavorite.ListOfRecipes.Add(recipe);
        var count = await _context.SaveChangesAsync();
        return count == 1;

    }

    public async Task<bool> DeleteUserFavoriteAsync(int FavoriteId)
    {
        var favorite = await _context.UserFavorites.FindAsync(FavoriteId);

        if (favorite?.UserId != FavoriteId)
            return false;

        _context.UserFavorites.Remove(favorite);
        return await _context.SaveChangesAsync() == 1;
    }
}

