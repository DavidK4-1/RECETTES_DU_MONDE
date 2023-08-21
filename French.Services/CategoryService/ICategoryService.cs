using System;
using French.Models.CatagoryModels;

namespace French.Services.CatagoryService
{
	public interface ICategoryService
	{
		Task<CategoryListItem?> CreateCategoryAsync(CategoryCreate request);

		Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync();

		Task<bool> AddCategoryToRecipeAsync(int categoryId, int recipeId);

		Task<bool> DeleteCategoryAsync(int categoryId);
    }
}

