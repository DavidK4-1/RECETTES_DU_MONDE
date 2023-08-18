
using French.Models.TokenModels;

namespace French.Services.TokenService;

public interface ITokenService {
    Task<TokenResponse?> GetTokenAsync(TokenRequest model);
}
