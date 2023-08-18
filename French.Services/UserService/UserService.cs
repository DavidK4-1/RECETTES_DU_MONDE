using French.Data;
using French.Data.Entities;
using French.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace French.Services.UserService;

public class UserService : IUserService {
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
                                         // in order to use you need tokens
    private readonly SignInManager<User> _signInManager;
    private readonly int _userId;

    public UserService(  ApplicationDbContext context,
                         UserManager<User> userManager,
                         SignInManager<User> signInManager) { 
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;

        //cheak if a user is signed in 
        var currUser = signInManager.Context.User;
        if (currUser.Identity.Name is not null) { 
            //retreve an id if signed in (put it into a private field)
            var userIdClaim = userManager.GetUserId(currUser);
            if (!int.TryParse(userIdClaim, out _userId))
                throw new Exception("invalid id");
        }
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
    public async Task<bool> UpdateUserAsync(UserUpdate model) {
        if (!await CheakEmailAvailabilityAsync(model.Email))
        {
            Console.WriteLine("Invalid email");
            return false;
        }
        if (!await CheakUserNameAvailibilityAsync(model.UserName))
        {
            Console.WriteLine("Invalid username");
            return false;
        }

        var userEntity = await _context.Users.FindAsync(_userId);
        userEntity.Email = model.Email;
        userEntity.UserName = model.UserName;
        
        return (await _userManager.UpdateAsync(userEntity)).Succeeded;
    }
    public async Task<bool> DeleteUserAsync() {
        var userEntity = await _context.Users.FindAsync(_userId);
        if (userEntity?.Id != _userId)
            return false;

        _context.Users.Remove(userEntity);
        return await _context.SaveChangesAsync() == 1;
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
