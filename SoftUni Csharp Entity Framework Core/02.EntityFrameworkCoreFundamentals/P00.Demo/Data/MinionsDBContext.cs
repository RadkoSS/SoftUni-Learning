using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using P00.Demo.Models;

namespace P00.Demo.Data
{
    public partial class MinionsDBContext : DbContext
    {
        public MinionsDBContext()
        {
        }

        public MinionsDBContext(DbContextOptions<MinionsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<EvilnessFactor> EvilnessFactors { get; set; } = null!;
        public virtual DbSet<Minion> Minions { get; set; } = null!;
        public virtual DbSet<Town> Towns { get; set; } = null!;
        public virtual DbSet<Villain> Villains { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.;database=MinionsDB;Integrated Security=true;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Minion>(entity =>
            {
                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Minions)
                    .HasForeignKey(d => d.TownId)
                    .HasConstraintName("FK__Minions__TownId__3C69FB99");

                entity.HasMany(d => d.Villains)
                    .WithMany(p => p.Minions)
                    .UsingEntity<Dictionary<string, object>>(
                        "MinionsVillain",
                        l => l.HasOne<Villain>().WithMany().HasForeignKey("VillainId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__MinionsVi__Villa__44FF419A"),
                        r => r.HasOne<Minion>().WithMany().HasForeignKey("MinionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__MinionsVi__Minio__440B1D61"),
                        j =>
                        {
                            j.HasKey("MinionId", "VillainId");

                            j.ToTable("MinionsVillains");
                        });
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Towns)
                    .HasForeignKey(d => d.CountryCode)
                    .HasConstraintName("FK__Towns__CountryCo__398D8EEE");
            });

            modelBuilder.Entity<Villain>(entity =>
            {
                entity.HasOne(d => d.EvilnessFactor)
                    .WithMany(p => p.Villains)
                    .HasForeignKey(d => d.EvilnessFactorId)
                    .HasConstraintName("FK__Villains__Evilne__412EB0B6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
