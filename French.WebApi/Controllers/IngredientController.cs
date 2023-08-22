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

        return await _ingredientService.CreateIngredientAsync(model) ? Ok(new TextResponse("Ingredient was created"))
                                                                     : BadRequest(new TextResponse("Ingredient was not created"));
    }
    [HttpGet]
    public async Task<IActionResult> GetAllIngredientsAsync()
        => Ok(await _ingredientService.GetAllIngredientItemsAsync());

    [HttpGet("{Id:int}")]
    public async Task<IActionResult> GetIngredientById([FromRoute] int Id) { 
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var ret = await _ingredientService.GetIngredientByIdAsync(Id);
        return ret is not null ? Ok(ret)
                               : BadRequest(new TextResponse("Not found"));
    }
    
}