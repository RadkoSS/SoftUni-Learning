using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUni.Models;

public class Department
{
    public Department()
    {
        this.Employees = new HashSet<Employee>();
    }

    [Key]
    [Column("DepartmentID")]
    public int DepartmentId { get; set; }

    [InverseProperty(nameof(Employee.Department))]
    public virtual ICollection<Employee> Employees { get; set; }

    [Column("ManagerID")]
    public int ManagerId { get; set; }

    [ForeignKey(nameof(ManagerId))]
    [InverseProperty(nameof(Employee.Departments))]
    public virtual Employee Manager { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;
}