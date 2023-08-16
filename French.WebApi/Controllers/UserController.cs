using French.Models.Responces;
using French.Models.TokenModels;
using French.Models.UserModels;
using French.Services.TokenService;
using French.Services.UserService;
using Microsoft.AspNetCore.Authorization;
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

    /*
    {in postman chapter 13.05(more info on using TOKENS)}swap to an Authorization tab. Once there, select the Type dropdown and choose Bearer Token. 
                                                         Paste the token value you got back in your response body into the new input field labeled Token
    */

    //TODO ENDPOINT &&& UserUpdate <- class
    //[Authorize, HttpPut("Update")]
    //public async Task<IActionResult> UpdateUserAsync([FromBody] UserUpdate update) { 
       // if (!ModelState.IsValid)
            //return BadRequest(ModelState);

    //}

    [Authorize, HttpDelete("Delete")]
    public async Task<IActionResult> DeleteUserAsync() 
        => await _userService.DeleteUserAsync() ? Ok(new TextResponse("user deleted"))
                                                : BadRequest(new TextResponse("How did you get this and not a 400"));

    [HttpPost("~/api/Token")]
    public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequest request) { 
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        TokenResponse? responce = await _tokenService.GetTokenAsync(request);
        return responce is null ? BadRequest(new TextResponse("Invalid username or password")) : Ok(responce);
    }
}
