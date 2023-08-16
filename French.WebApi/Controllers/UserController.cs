using French.Models.Responces;
using French.Models.TokenModels;
using French.Models.UserModels;
using French.Services.TokenService;
using French.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace French.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase {
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    
    public UserController(IUserService userService, ITokenService tokenService) {
        _userService = userService;
        _tokenService = tokenService;
    }

    // "~/" <- gets rid of the route string specified
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegister model) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return await _userService.RegisterUserAsync(model) ? Ok(new TextResponse("User was registered")) 
                                                           : BadRequest(new TextResponse("User could not be registered"));
    }
    [HttpPost("~/api/Token")]
    public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequest request) { 
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        TokenResponse? responce = await _tokenService.GetTokenAsync(request);
        return responce is null ? BadRequest(new TextResponse("Invalid username or password")) : Ok(responce);
    }
    //TODO
    //[Authorize, HttpPut()]
    //[Authorize, HttpDelete()]
}
