namespace P01_StudentSystem.Data;

using Microsoft.EntityFrameworkCore;

using Common;
using Models;

public class StudentSystemContext : DbContext
{
    public StudentSystemContext()
    {
        
    }

    public StudentSystemContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; } = null!;

    public virtual DbSet<Homework> Homeworks { get; set; } = null!;

    public virtual DbSet<Resource> Resources { get; set; } = null!;

    public virtual DbSet<Student> Students { get; set; } = null!;

    public virtual DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

    //Connection configurations
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }

        base.OnConfiguring(optionsBuilder);
    }

    //FluentAPI and Entities configurations
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentCourse>(e =>
        {
            e.HasKey(pk => new
            {
                pk.StudentId,
                pk.CourseId
            });

            e.HasOne(s => s.Student)
                .WithMany(sc => sc.StudentsCourses)
                .HasForeignKey(s => s.StudentId);

            e.HasOne(s => s.Course)
                .WithMany(sc => sc.StudentsCourses)
                .HasForeignKey(c => c.CourseId);
        });

        base.OnModelCreating(modelBuilder);
    }
}