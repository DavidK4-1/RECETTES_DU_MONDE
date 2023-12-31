﻿using System.ComponentModel.DataAnnotations;

namespace French.Models.IngredientModels;

public class CreateIngredient {
    [Required, MaxLength(50)]
    public string Name { get; set; }
    [Required, MaxLength(1000)]
    public string Description { get; set; }
}
