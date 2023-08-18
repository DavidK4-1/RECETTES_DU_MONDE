﻿using System.ComponentModel.DataAnnotations;

namespace French.Models.IngredientModels;

public class IngredientItem {
    [Required, MaxLength(50)]
    public string Name { get; set; } = null!;
    [Required, MaxLength(1000)]
    public string Description { get; set; } = null!;
}
