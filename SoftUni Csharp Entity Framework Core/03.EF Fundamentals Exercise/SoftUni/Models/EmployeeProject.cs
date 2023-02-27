namespace SoftUni.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class EmployeeProject
{
    [ForeignKey(nameof(EmployeeId))]
    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }

    [ForeignKey(nameof(ProjectId))]
    public int ProjectId { get; set; }

    public virtual Project Project { get; set; }
}