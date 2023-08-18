using System.ComponentModel.DataAnnotations;

namespace French.Models.UserModels;
//TODO
public class UserUpdate {
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required, MinLength(4)]
    public string UserName { get; set; } = string.Empty;
    [Required, MinLength(4)]
    public string PasswordNew { get; set; } = string.Empty;
    [Required, MinLength(4)]
    public string PasswordOrigin { get; set; } = string.Empty;
}
