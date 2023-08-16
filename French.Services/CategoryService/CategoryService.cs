using French.Models.CatagoryModels;
using French.Data.Entities;
using Microsoft.EntityFrameworkCore;
using French.Data;

namespace French.Services.CatagoryService;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;
    private readonly int _userId;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync()
    {
        List<CategoryListItem> category = await _context.Categories
            .Where(entity => entity.CategoryId == _userId)
            .Select(entity => new CategoryListItem
            {
                Id = entity.CategoryId,
                Name = entity.Name
            })
            .ToListAsync();

        return category;
    }

    public async Task<CategoryListItem?> CreateCategoryAsync(CategoryCreate request)
    {
        Category category = new()
        {
            Name = request.Name,
        };
        _context.Categories.Add(category);
        var numberOfChanges = await _context.SaveChangesAsync();

        if (numberOfChanges != 1)
            return null;

        CategoryListItem response = new()
        {
            Id = category.CategoryId,
            Name = category.Name
        };

        return response;
    }
        


}


