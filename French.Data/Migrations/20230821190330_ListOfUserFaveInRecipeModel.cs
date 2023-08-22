using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace French.Data.Migrations
{
    /// <inheritdoc />
    public partial class ListOfUserFaveInRecipeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_UserFavorites_UserFavoriteUserId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_UserFavoriteUserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "UserFavoriteUserId",
                table: "Recipes");

            migrationBuilder.CreateTable(
                name: "RecipeUserFavorite",
                columns: table => new
                {
                    ListOfRecipesRecipeId = table.Column<int>(type: "int", nullable: false),
                    UserFavoritesUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeUserFavorite", x => new { x.ListOfRecipesRecipeId, x.UserFavoritesUserId });
                    table.ForeignKey(
                        name: "FK_RecipeUserFavorite_Recipes_ListOfRecipesRecipeId",
                        column: x => x.ListOfRecipesRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeUserFavorite_UserFavorites_UserFavoritesUserId",
                        column: x => x.UserFavoritesUserId,
                        principalTable: "UserFavorites",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeUserFavorite_UserFavoritesUserId",
                table: "RecipeUserFavorite",
                column: "UserFavoritesUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeUserFavorite");

            migrationBuilder.AddColumn<int>(
                name: "UserFavoriteUserId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserFavoriteUserId",
                table: "Recipes",
                column: "UserFavoriteUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_UserFavorites_UserFavoriteUserId",
                table: "Recipes",
                column: "UserFavoriteUserId",
                principalTable: "UserFavorites",
                principalColumn: "UserId");
        }
    }
}
