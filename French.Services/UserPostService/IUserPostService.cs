using French.Models.UserPostModels;
using French.Data.Entities;

namespace French.Services.UserPostService;

public interface IUserPostService
{
    Task<bool> CreateUserPostAsync(UserPostCreate request);
    Task<bool> DeleteUserPostAsync(int userPostId);
    Task<bool> DeleteUserPostsByRecipeAsync(int recipeId);
    Task<List<UserPost>> GetUserPostsByRecipeAsync(int recipeId);
}
