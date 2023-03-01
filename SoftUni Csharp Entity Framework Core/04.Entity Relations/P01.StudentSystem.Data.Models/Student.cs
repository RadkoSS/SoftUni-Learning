namespace P01_StudentSystem.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;


public class Student
{
    public Student()
    {
        this.Homeworks = new HashSet<Homework>();
        this.StudentsCourses = new HashSet<StudentCourse>();
    }

    [Key]
    public int StudentId { get; set; }

    [Unicode]
    [MaxLength(GlobalConstants.StudentNameMaxLength)]
    public string Name { get; set; } = null!;

    [MinLength(GlobalConstants.PhoneMinMaxLength)]
    [Column(TypeName = "varchar(10)")]
    public string? PhoneNumber { get; set; }

    public DateTime RegisteredOn { get; set; }

    public DateTime? Birthday { get; set; }

    public ICollection<Homework> Homeworks { get; set; }

    public ICollection<StudentCourse> StudentsCourses { get; set; }
}