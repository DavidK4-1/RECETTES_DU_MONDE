using French.Data.Entities;
using French.Models.CatagoryModels;
using French.Models.Responces;
using French.Services.CatagoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace French.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryCreate request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _categoryService.CreateCategoryAsync(request);
        if (response is not null)
            return Ok(response);

        return BadRequest(new TextResponse("Could not create category :( ."));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }


    [HttpPut("{categoryId}/{recipeId}")]
    public async Task<IActionResult> AddCategoryToRecipe([FromRoute]int categoryId, [FromRoute]int recipeId)
    {
        var response = await _categoryService.AddCategoryToRecipeAsync(categoryId, recipeId);

        return Ok(response);
    }

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int categoryId)
    {
        var response = await _categoryService.DeleteCategoryAsync(categoryId);

        return Ok(response);
    }
}

