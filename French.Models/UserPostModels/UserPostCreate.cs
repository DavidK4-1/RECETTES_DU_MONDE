using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace French.Models.UserPostModels;

public class UserPostCreate
{
    [Required]
    public int RecipeId { get; set; }
    
    [MaxLength(100)]
    public string ReviewText { get; set; } = string.Empty;

    [Required]
    public int ReviewRating { get; set; }

    [Required]
    public DateTime ReviewDate { get; set; }    
}