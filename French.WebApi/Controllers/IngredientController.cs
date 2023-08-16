using French.Models.Responces;
using French.Models.TokenModels;
using French.Models.IngredientModels;
using French.Services.TokenService;
using French.Services.IngredientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using French.Models.UserModels;

namespace French.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientController : ControllerBase {
    private readonly IIngredientService _ingredientService;

    public IngredientController(IIngredientService ingredientService) {
        _ingredientService = ingredientService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateIngredientAsync([FromBody] CreateIngredient model) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return await _ingredientService.CreateIngredientAsync(model) ? Ok(new TextResponse("User was registered"))
                                                                     : BadRequest(new TextResponse("User could not be registered"));
    }
    //get ingredient by id

}