using French.Models.Responces;
using French.Services.TokenService;
using French.Services.UserFavoritesService;
using French.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace French.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserFavoritesController : ControllerBase
{
    private readonly IUserFavoritesService _userFavoritesService;

    public UserFavoritesController(IUserFavoritesService UserFavoritesService)
    {
        _userFavoritesService = UserFavoritesService;

    }

    [HttpPost]
    public async Task<IActionResult> CreateUserFavoriteAsync()
    {
        var userFavorite = await _userFavoritesService.CreateUserFavoriteAsync();
        return Ok(userFavorite);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFavorites()
    {
        var favorites = await _userFavoritesService.GetAllUserFavoritesAsync();
        return Ok(favorites); //Return Favorites
    }


[HttpPut("{recipeId}")]
public async Task<IActionResult> AddRecipeToFavorites([FromRoute] int recipeId)
{
    var addedRecipeDetail = await _userFavoritesService.AddRecipeToFavoritesAsync(recipeId);

    if (addedRecipeDetail != null)
    {
            string message = $"`{addedRecipeDetail.Title}` sounds delicious! It has been added to your favorites.";
        return Ok(message);
    }
    else
    {
        return BadRequest($"Favorite {recipeId} could NOT be added!");
    }
}

    
    [HttpDelete("{recipeId}")]
    public async Task<IActionResult> DeleteFavorite([FromRoute] int recipeId)
    {
        return await _userFavoritesService.DeleteUserFavoriteAsync(recipeId)
            ? Ok($"Favorite {recipeId} was deleted successfully.")
            : BadRequest($"Favorite {recipeId} could NOT be deleted!");

    }
    
}

