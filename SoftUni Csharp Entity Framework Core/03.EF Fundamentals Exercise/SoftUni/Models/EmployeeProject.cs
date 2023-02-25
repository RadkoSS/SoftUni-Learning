namespace SoftUni.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class EmployeeProject
{
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }

    public Employee Employee { get; set; }

    [ForeignKey("Project")]
    public int ProjectId { get; set; }

    public Project Project { get; set; }
}