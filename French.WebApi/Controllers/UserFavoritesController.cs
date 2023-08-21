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
 //   private readonly IUserService _userService;
 //   private readonly ITokenService _tokenService;
    private readonly IUserFavoritesService _userFavoritesService;

    public UserFavoritesController(IUserFavoritesService UserFavoritesService, ITokenService tokenService)
    {
        _userFavoritesService = UserFavoritesService;
    //    _tokenService = tokenService;
     //   _userService = userService;
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
        var favorites = await _userFavoritesService.GetAllFavoritesAsync();
        return Ok(favorites); //Return Favorites
    }

    [HttpPut("{recipeId}")]
    public async Task<IActionResult> AddRecipeToFavorites([FromRoute]int recipeId)
    {
        var response = await _userFavoritesService.AddRecipeToFavoritesAsync(recipeId);
        if (response)
            return Ok(response);

        return BadRequest(new TextResponse("Could not add recipe to favorites!"));
    }

    [HttpDelete("{FavoriteId:int}")]
    public async Task<IActionResult> DeleteFavorite([FromRoute] int FavoriteId)
    {
        return await _userFavoritesService.DeleteUserFavoriteAsync(FavoriteId)
            ? Ok($"Favorite {FavoriteId} was deleted successfully.")
            : BadRequest($"Favorite {FavoriteId} could NOT be deleted!");
    }

}

