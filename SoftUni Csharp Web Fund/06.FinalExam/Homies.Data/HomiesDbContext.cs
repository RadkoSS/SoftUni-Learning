namespace Homies.Data;

using System.Reflection;

using Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class HomiesDbContext : IdentityDbContext
{
    public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
        : base(options)
    {
    }
    public DbSet<Event> Events { get; set; } = null!;

    public DbSet<Type> Types { get; set; } = null!;

    public DbSet<EventParticipant> EventParticipants { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(HomiesDbContext)) ?? Assembly.GetExecutingAssembly());

        modelBuilder.Entity<EventParticipant>().HasKey(pk => new
        {
            pk.HelperId,
            pk.EventId
        });

        modelBuilder.Entity<EventParticipant>()
            .HasOne(x => x.Event)
            .WithMany(x => x.EventsParticipants)
            .OnDelete(DeleteBehavior.NoAction);

        base.OnModelCreating(modelBuilder);
    }
}