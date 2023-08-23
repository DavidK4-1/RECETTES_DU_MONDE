using French.Models.Responces;
using French.Models.UserPostModels;
using French.Services.UserPostService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace French.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserPostController : ControllerBase
{
    private readonly IUserPostService _userPostService;

    public UserPostController(IUserPostService userPostService)
    {
        _userPostService = userPostService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserPost([FromBody] UserPostCreate request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _userPostService.CreateUserPostAsync(request);
        if (response == true)
            return Ok(response);

        return BadRequest(new TextResponse("Post failed to be created."));
    }

    [HttpGet]
    public async Task<IActionResult> GetUserPostsByRecipe([FromRoute] int recipeId)
    {
        var posts = await _userPostService.GetUserPostsByRecipeAsync(recipeId);
        return posts is not null
            ? Ok(posts)
            : NotFound();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUserPost([FromRoute] int userPostId)
    {
        return await _userPostService.DeleteUserPostAsync(userPostId)
            ? Ok($"UserPost {userPostId} was deleted successfully.")
            : BadRequest($"UserPost {userPostId} failed to be deleted.");
    }
    /*
    [HttpDelete]
    public async Task<IActionResult> DeleteUserPostsByRecipe([FromRoute] int recipeId)
    {
        return await _userPostService.DeleteUserPostsByRecipeAsync(recipeId)
            ? Ok("UserPosts were deleted successfully.")
            : BadRequest("UserPosts failed to be deleted.");
    }
    */
}