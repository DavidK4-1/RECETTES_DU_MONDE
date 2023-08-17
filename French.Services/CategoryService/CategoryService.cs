﻿using French.Models.CatagoryModels;
using French.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using French.Data;

namespace French.Services.CatagoryService;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;
    private readonly int _userId;

    public CategoryService(UserManager<User> userManager,
                           SignInManager<User> signInManager,
                           ApplicationDbContext context)
    {
        var currentUser = signInManager.Context.User;
        var userIdClaim = userManager.GetUserId(currentUser);
        var hasValidId = int.TryParse(userIdClaim, out _userId);

        if (hasValidId == false)
            throw new Exception("Attempted to build CategoryService without Id claim. :( ");
        _context = context;

    }

    public async Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync()
    {
        List<CategoryListItem> categories = await _context.Categories
            .Where(entity => entity.CategoryId == _userId)
            .Select(entity => new CategoryListItem
            {
                Name = entity.Name
            })
            .ToListAsync();

        return categories;
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
            Name = category.Name
        };

        return response;
    }
        
}


