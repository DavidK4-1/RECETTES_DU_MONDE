using French.Data;
using French.Data.Entities;
using French.Models.UserPostModels;
using Microsoft.EntityFrameworkCore;

namespace French.Services.UserPostService;

public class UserPostService : IUserPostService
{
    private readonly ApplicationDbContext _dbContext;

    public UserPostService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateUserPostAsync(UserPostCreate request)
    {
        UserPost userPost = new()
        {
            RecipeId = request.RecipeId,
            ReviewText = request.ReviewText,
            ReviewRating = request.ReviewRating,
            ReviewDate = request.ReviewDate
        };

        _dbContext.UserPosts.Add(userPost);
        return await _dbContext.SaveChangesAsync() == 1;
    }

    public async Task<bool> DeleteUserPostAsync(int userPostId)
    {
        var userPost = await _dbContext.UserPosts.FindAsync(userPostId);

        if (userPost?.UserPostId != userPostId)
            return false;

        _dbContext.UserPosts.Remove(userPost);
        return await _dbContext.SaveChangesAsync() == 1;
    }
}