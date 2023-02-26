﻿using Microsoft.EntityFrameworkCore;

using SoftUni.Models;

namespace SoftUni.Data;

public class SoftUniContext : DbContext
{
    public SoftUniContext()
    {
    }

    public SoftUniContext(DbContextOptions<SoftUniContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; } = null!;

    public virtual DbSet<Department> Departments { get; set; } = null!;

    public virtual DbSet<Employee> Employees { get; set; } = null!;

    public virtual DbSet<Project> Projects { get; set; } = null!;

    public virtual DbSet<Town> Towns { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=SoftUni;Integrated Security=True;Encrypt=False");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasOne(d => d.Town)
                .WithMany(p => p.Addresses)
                .HasForeignKey(d => d.TownId)
                .HasConstraintName("FK_Addresses_Towns");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasOne(d => d.Manager)
                .WithMany(p => p.Departments)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Departments_Employees");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne(d => d.Address)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_Employees_Addresses");

            entity.HasOne(d => d.Department)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Departments");

            entity.HasOne(d => d.Manager)
                .WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Employees_Employees");
        });

        modelBuilder.Entity<EmployeeProject>(entity =>
        {
            entity.HasKey(pk => new { pk.EmployeeId, pk.ProjectId });

            entity.HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeesProjects)
                .HasForeignKey(ep => ep.EmployeeId);

            entity.HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeesProjects)
                .HasForeignKey(ep => ep.ProjectId);
        });
    }
}