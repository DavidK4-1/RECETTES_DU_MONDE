using French.Models.CatagoryModels;
using French.Data.Entities;
using Microsoft.EntityFrameworkCore;
using French.Data;

namespace French.Services.CatagoryService;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync()
    {
        List<CategoryListItem> categories = await _context.Categories
            .Select(entity => new CategoryListItem
            {
                Name = entity.Name,
                Description = entity.Description
            })
            .ToListAsync();

        return categories;
    }

    public async Task<CategoryListItem?> CreateCategoryAsync(CategoryCreate request)
    {
        Category category = new()
        {
            Name = request.Name,
            Description = request.Description
        };

        _context.Categories.Add(category);
        var numberOfChanges = await _context.SaveChangesAsync();

        if (numberOfChanges != 1)
            return null;

        CategoryListItem response = new()
        {
            Name = category.Name,
            Description = category.Description
        };

        return response;
    }

    public async Task<bool> AddCategoryToRecipeAsync(int categoryId, int recipeId)
    {

        var category = await _context.Categories.FindAsync(categoryId);
        var recipe = await _context.Recipes.FindAsync(recipeId);
        recipe?.ListOfCategorys.Add(category);
        return await _context.SaveChangesAsync() == 1; 
    }

    public async Task<bool> DeleteCategoryAsync(int categoryId)
    {
        var category = await _context.Categories.FindAsync(categoryId);

        if (category?.CategoryId != categoryId)
            return false;

        _context.Categories.Remove(category);
        return await _context.SaveChangesAsync() == 1;
    }

}


