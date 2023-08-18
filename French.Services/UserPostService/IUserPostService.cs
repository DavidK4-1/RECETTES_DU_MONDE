using French.Models.UserPostModels;

namespace French.Services.UserPostService;

public interface IUserPostService
{
    Task<bool> CreateUserPostAsync(UserPostCreate request);
}
