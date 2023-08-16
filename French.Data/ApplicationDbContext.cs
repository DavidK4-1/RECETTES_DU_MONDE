using French.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace French.Data;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int> {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<UserFavorite> UserFavorites { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    /*
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<UserPost> UserPosts { get; set; }
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().ToTable("users");
    }
}
