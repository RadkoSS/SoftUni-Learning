using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUni.Models;

public class Project
{
    public Project()
    {
        this.EmployeesProjects = new HashSet<EmployeeProject>();
    }

    [Key]
    [Column("ProjectID")]
    public int ProjectId { get; set; }

    [ForeignKey(nameof(ProjectId))]
    public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? EndDate { get; set; }
}