using French.Models.Responces;
using French.Models.UserModels;
using French.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace French.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase {
    private readonly IUserService _userService;
    
    public UserController(IUserService userService) {
        _userService = userService;
    }

    // "~/" <- gets rid of the route string specified
    [HttpPost("users/register")]
    public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegister model) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return await _userService.RegisterUserAsync(model) ? Ok(new TextResponse("User was registered")) 
                                                           : BadRequest(new TextResponse("User could not be registered"));
    }
}
