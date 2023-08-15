using French.Data.Entities;
using French.Models.TokenModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace French.Services.TokenService;

public class TokenService : ITokenService {
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;

    public TokenService(IConfiguration configuration, UserManager<User> userManager) {
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<TokenResponse?> GetTokenAsync(TokenRequest model) { 
        User? entity = await GetValidUserAsync(model);

        return entity is null ? null: await GenerateTokenAsync(entity);
    }

    private async Task<User?> GetValidUserAsync(TokenRequest model) {
        var user = await _userManager.FindByNameAsync(model.UserName);
        if (user is null)
            return null;

        var isValidPassword = await _userManager.CheckPasswordAsync(user, model.Password);
        return isValidPassword ? user: null;
    }
    private async Task<TokenResponse> GenerateTokenAsync(User entity) {
        List<Claim> claims = await GetUserClaimsAsync(entity);
        SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor(claims);

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new TokenResponse()
        {
            Token = tokenHandler.WriteToken(token),
            IssuedAt = token.ValidFrom,
            Expires = token.ValidTo
        };
    }
    private async Task<List<Claim>> GetUserClaimsAsync(User entity) {
        List<Claim> claims = new() {
            new Claim(ClaimTypes.NameIdentifier, entity.Id.ToString()),
            new Claim(ClaimTypes.Name, entity.UserName!),
            new Claim(ClaimTypes.Email, entity.Email!)
        };

        foreach (var role in await _userManager.GetRolesAsync(entity))
            claims.Add(new Claim(ClaimTypes.Role, role));

        return claims;
    }
    private SecurityTokenDescriptor GetTokenDescriptor(List<Claim> claims) {
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
        var secret = new SymmetricSecurityKey(key);
        var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

        return new SecurityTokenDescriptor()
        {
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            Subject = new ClaimsIdentity(claims),
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddDays(14),
            SigningCredentials = signingCredentials
        };
    }
}
