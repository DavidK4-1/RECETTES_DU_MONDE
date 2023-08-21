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

      //  await _context.SaveChangesAsync();

     //   var user = await _context.Users.FindAsync(_userId);

    //    user.UserFavoriteObj = await _context.UserFavorites.FindAsync(favorite.FavoriteId);

        var check = await _context.SaveChangesAsync();

        return check == 1;

    }
    
    public async Task<List<French.Data.Entities.Recipe>> GetAllFavoritesAsync()
    {
        /*
        List<FavoritesListItem> favorites = await _context.UserFavorites
            .Where(entity => entity.UserId == _userId)
            .Select(entity => new FavoritesListItem
            {
                Id = entity.UserId,  // SELECTING ONLY 1 FROM LIST
                ListOfRecipes = new RecipeDetail()
                {
                    Description = entity.ListOfRecipes.ToList()[0].Description,
                    Title = entity.ListOfRecipes.ToList()[0].Title,
                    Instruction = entity.ListOfRecipes.ToList()[0].Instruction,
                    RecipeId = entity.ListOfRecipes.ToList()[0].RecipeId
                }
            })
            .ToListAsync();
        */
        var favorites = (await _context.UserFavorites.FindAsync(_userId)).ListOfRecipes.ToList();
        return favorites;
    }

      
    public async Task<bool> AddRecipeToFavoritesAsync(int recipeId)
    {
        var userfavorite = await _context.UserFavorites.FindAsync(_userId);
        var recipe = await _context.Recipes.FindAsync(recipeId);
        userfavorite.ListOfRecipes.Add(recipe); // :( This line bad
        var count = await _context.SaveChangesAsync();
        return count == 1;

    }
    
    public async Task<bool> DeleteUserFavoriteAsync(int FavoriteId)
    {
        var favorite = await _context.UserFavorites.FindAsync(FavoriteId);

    //    if (favorite?.FavoriteId != FavoriteId)
            return false;

        _context.UserFavorites.Remove(favorite);
        return await _context.SaveChangesAsync() == 1;
    }
}

