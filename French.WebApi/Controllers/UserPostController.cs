using French.Models.Responces;
using French.Models.UserPostModels;
using French.Services.UserPostService;
using Microsoft.AspNetCore.Mvc;

namespace French.WebApi.Controllers;

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
    }