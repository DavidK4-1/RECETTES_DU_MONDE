namespace French.Models.Recipe
{
    public class RecipeDetail
    {
        public int RecipeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Instruction { get; set; } = string.Empty;

        public ICollection<French.Data.Entities.Ingredient> ListOfIngredients { get; set; } = null!;
    }
}