using System;
using French.Models.CatagoryModels;

namespace French.Services.CatagoryService;

public interface ICategoryService
{
	Task<CategoryListItem?> CreateCategoryAsync(CategoryCreate request);

	Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync();

	Task<string> AddCategoryToRecipeAsync(int categoryId, int recipeId);

	Task<string> DeleteCategoryAsync(int categoryId);
    }

