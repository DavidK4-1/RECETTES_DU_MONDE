using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace French.Models.RecipeModels;

    public class RecipeDetails
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Instruction { get; set; } = string.Empty;

        
    }
