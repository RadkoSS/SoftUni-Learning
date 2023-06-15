namespace Library.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Models.Entities;

using static Seeding.BookSeeder;
using static Seeding.CategorySeeder;

public class LibraryDbContext : IdentityDbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Category>().HasData(SeedCategories());

        builder.Entity<Book>().HasData(SeedBooks());

        builder.Entity<IdentityUserBook>().HasKey(pk => new
        {
            pk.CollectorId,
            pk.BookId
        });

        builder.Entity<Book>().Property(b => b.Rating).HasPrecision(18, 2);

        base.OnModelCreating(builder);
    }

    public DbSet<Book> Books { get; set; } = null!;

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<IdentityUserBook> IdentityUserBooks { get; set; } = null!;
}