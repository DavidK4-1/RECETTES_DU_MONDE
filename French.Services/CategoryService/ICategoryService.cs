using System;
using French.Models.CatagoryModels;

namespace French.Services.CatagoryService
{
	public interface ICategoryService
	{
		Task<CategoryListItem?> CreateCategoryAsnc(CategoryCreate request);

		Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync();

	}
}

