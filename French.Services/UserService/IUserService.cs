using French.Models.UserModels;

namespace French.Services.UserService;

public interface IUserService {
    Task<bool> RegisterUserAsync(UserRegister model);
    Task<bool> DeleteUserAsync();
}
