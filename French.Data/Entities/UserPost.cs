using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace French.Data.Entities;

public class UserPost
{
    [Key]
    public int UserPostId { get; set; }

    [ForeignKey("Recipe")]
    public int RecipeId { get; set; }

    [MaxLength(100)]
    public string ReviewText { get; set; } = string.Empty;

    [Required]
    public int ReviewRating { get; set; }

    [Required]
    public DateTime ReviewDate { get; set; }
}
