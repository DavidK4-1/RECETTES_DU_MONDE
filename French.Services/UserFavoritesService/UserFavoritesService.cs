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
        var userFavorites = await _context.UserFavorites
            .Where(e => e.UserId == _userId)
            .Include(uf => uf.ListOfRecipes)
            .Select(uf => uf.ListOfRecipes)
            .FirstOrDefaultAsync();

        if (userFavorites == null)
        {
            return new List<RecipeDetail>(); // Return an empty list if user has no favorites
        }

        var returnList = userFavorites
            .Select(recipe => new RecipeDetail
            {
                RecipeId = recipe.RecipeId,
                Title = recipe.Title,
                Description = recipe.Description,
                Instruction = recipe.Instruction
            })
            .ToList();

        return returnList;
    }

    public async Task<RecipeDetail> AddRecipeToFavoritesAsync(int recipeId)
    {
        var userfavorite = await _context.UserFavorites
            .Include(uf => uf.ListOfRecipes)
            .Where(uf => uf.UserId == _userId)
            .FirstOrDefaultAsync();

        if (userfavorite == null)
        {
            return null; // User not found
        }

        var recipe = await _context.Recipes
            .Where(r => r.RecipeId == recipeId)
            .FirstOrDefaultAsync();

        if (recipe == null)
        {
            return null; // Recipe not found
        }

        userfavorite.ListOfRecipes.Add(recipe);
        await _context.SaveChangesAsync();

        // Map Recipe to RecipeDetail
        RecipeDetail addedRecipeDetail = new RecipeDetail
        {
            RecipeId = recipe.RecipeId,
            Title = recipe.Title,
            Description = recipe.Description,
            Instruction = recipe.Instruction,
            // Add other properties as needed
        };

        return addedRecipeDetail;
    }

    public async Task<bool> DeleteUserFavoriteAsync(int recipeId)
    {
        var user = await _context.UserFavorites
            .Where(e => e.UserId == _userId)
            .Include(l => l.ListOfRecipes)
            .FirstOrDefaultAsync();

        if (user == null)
            return false;

        var recipeToRemove = user.ListOfRecipes.FirstOrDefault(r => r.RecipeId == recipeId);

        if (recipeToRemove == null)
            return false;

        user.ListOfRecipes.Remove(recipeToRemove);

        return await _context.SaveChangesAsync() == 1;
    }
}

