namespace MusicHub.Data;

using Microsoft.EntityFrameworkCore;

using Models;

public class MusicHubDbContext : DbContext
{
    public MusicHubDbContext()
    {
    }

    public MusicHubDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Song> Songs { get; set; } = null!;

    public virtual DbSet<Album> Albums { get; set; } = null!;

    public virtual DbSet<Performer> Performers { get; set; } = null!;

    public virtual DbSet<Producer> Producers { get; set; } = null!;

    public virtual DbSet<Writer> Writers { get; set; } = null!;

    public virtual DbSet<SongPerformer> SongsPerformers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(Configuration.ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<SongPerformer>(e =>
        {
            e.HasKey(pk => new { pk.SongId, pk.PerformerId });

            e.HasOne(s => s.Song)
                .WithMany(p => p.SongPerformers)
                .HasForeignKey(s => s.SongId);

            e.HasOne(p => p.Performer)
                .WithMany(s => s.PerformerSongs)
                .HasForeignKey(p => p.PerformerId);
        });

        builder.Entity<Song>(e =>
        {
            e.Property(s => s.CreatedOn).HasColumnType("date");
        });

        builder.Entity<Album>(e =>
        {
            e.Property(a => a.ReleaseDate).HasColumnType("date");
        });
    }
}