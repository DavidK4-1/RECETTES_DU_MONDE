﻿using System.ComponentModel.DataAnnotations;

namespace French.Data.Entities;

public class Category
{
    [Key]
    public int CategoryId { get; set; } // Key

    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [MinLength(1), MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<Recipe> ListOfRecipes { get; set; } = null!; 

    public Category()
    {
        ListOfRecipes = new HashSet<Recipe>();
    }

}
