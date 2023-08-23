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
                CategoryId = entity.CategoryId,
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
            CategoryId = category.CategoryId,
            Name = category.Name,
            Description = category.Description
        };

        return response;
    }

    public async Task<string> AddCategoryToRecipeAsync(int categoryId, int recipeId)
    {

        var category = await _context.Categories.FindAsync(categoryId);
        var recipe = await _context.Recipes.FindAsync(recipeId);
        if (category == null || recipe == null)
        {
            return "Failed to associate category with recipe!";
        }
        recipe.ListOfCategorys.Add(category);
        await _context.SaveChangesAsync();

        string success = $"Category: `{category.Name}` has been added to Recipe: `{recipe.Title}`.";
        return success;
    }

    public async Task<string> DeleteCategoryAsync(int categoryId)
    {
        var category = await _context.Categories.FindAsync(categoryId);

        if (category == null)
        {
            return "Failed to delete category!";
        }
        var categoryName = category.Name;  // Need to capture Name before removing it!
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        string success = $"Category: `{categoryName}` was deleted.";
        return success;
    }

}


