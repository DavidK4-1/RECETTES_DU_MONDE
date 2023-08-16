using System.ComponentModel.DataAnnotations;

namespace French.Models.RecipeModels;

public class RecipeCreate
{
    [Required]
    [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
    [MaxLength(100, ErrorMessage = "{0} must be no more than {1} characters long.")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(200, ErrorMessage = "{0} must be no more than {1} characters long.")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [MaxLength(8000, ErrorMessage = "{0} must be no more than {1} characters long.")]
    public string Instruction { get; set; } = string.Empty;

    
}