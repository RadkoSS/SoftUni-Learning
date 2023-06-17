namespace Library.Data;

using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Models.Entities;

public class LibraryDbContext : IdentityDbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<IdentityUserBook> IdentityUserBooks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(LibraryDbContext)) ?? Assembly.GetExecutingAssembly());

        builder.Entity<IdentityUserBook>().HasKey(pk => new
        {
            pk.CollectorId,
            pk.BookId
        });

        builder.Entity<Book>().Property(b => b.Rating).HasPrecision(18, 2);

        base.OnModelCreating(builder);
    }
}