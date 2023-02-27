﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUni.Models;

public class Employee
{
    public Employee()
    {
        this.Departments = new HashSet<Department>();
        this.InverseManager = new HashSet<Employee>();
        this.EmployeesProjects = new HashSet<EmployeeProject>();
    }

    [Key]
    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; }

    [Column("DepartmentID")]
    public int DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    [InverseProperty("Employees")]
    public virtual Department Department { get; set; } = null!;

    [Column("ManagerID")]
    public int? ManagerId { get; set; }

    [ForeignKey(nameof(ManagerId))]
    [InverseProperty(nameof(InverseManager))]
    public virtual Employee? Manager { get; set; }

    [InverseProperty(nameof(Manager))]
    public virtual ICollection<Employee> InverseManager { get; set; }

    [Column("AddressID")]
    public int? AddressId { get; set; }

    [ForeignKey(nameof(AddressId))]
    [InverseProperty("Employees")]
    public virtual Address? Address { get; set; }

    [InverseProperty("Manager")]
    public virtual ICollection<Department> Departments { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? MiddleName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string JobTitle { get; set; } = null!;

    [Column(TypeName = "smalldatetime")]
    public DateTime HireDate { get; set; }

    [Column(TypeName = "decimal(15, 4)")]
    public decimal Salary { get; set; }
}