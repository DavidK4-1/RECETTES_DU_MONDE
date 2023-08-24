using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace French.Models.UserPostModels;

public class UserPostItem
{
    public int UserPostId { get; set; }

    [MaxLength(100)]
    public string ReviewText { get; set; } = string.Empty;

    [Required]
    public int ReviewRating { get; set; }

    [Required]
    public DateTime ReviewDate { get; set; }
}
