using French.Data;
using French.Data.Entities;
using French.Models.UserModels;
using Microsoft.AspNetCore.Identity;

namespace French.Services.UserService;

public class UserService : IUserService {
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
                                         // in order to use you need tokens
    private readonly SignInManager<User> _signInManager;

    public UserService(  ApplicationDbContext context,
                         UserManager<User> userManager,
                         SignInManager<User> signInManager) { 
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public async Task<bool> RegisterUserAsync(UserRegister model) {
        if (!await CheakEmailAvailabilityAsync(model.Email)) {
            Console.WriteLine("Invalid email");
            return false;
        }
        if (!await CheakUserNameAvailibilityAsync(model.UserName)) {
            Console.WriteLine("Invalid username");
            return false;
        }

        User entity = new() {
            Email = model.Email,
            UserName = model.UserName,
        };

        IdentityResult registerResult = await _userManager.CreateAsync(entity, model.Password);
        
        return registerResult.Succeeded;
    }

    private async Task<bool> CheakUserNameAvailibilityAsync(string userName) { 
        User? existingUser = await _userManager.FindByNameAsync(userName);
        return existingUser is null;
    }

    private async Task<bool> CheakEmailAvailabilityAsync(string email) {
        User? existingUser = await _userManager.FindByEmailAsync(email);
        return existingUser is null;
    }
}
