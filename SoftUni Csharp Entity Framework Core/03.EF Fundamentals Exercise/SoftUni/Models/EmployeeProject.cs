namespace SoftUni.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class EmployeeProject
{
    [ForeignKey("EmployeeId")]
    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }

    [ForeignKey("ProjectId")]
    public int ProjectId { get; set; }

    public virtual Project Project { get; set; }
}