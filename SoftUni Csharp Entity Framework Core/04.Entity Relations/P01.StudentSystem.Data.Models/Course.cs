namespace P01_StudentSystem.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using Common;

public class Course
{
    public Course()
    {
        this.Resources = new HashSet<Resource>();
        this.Homeworks = new HashSet<Homework>();
        this.StudentsCourses = new HashSet<StudentCourse>();
    }

    [Key]
    public int CourseId { get; set; }

    [Unicode] 
    [MaxLength(GlobalConstants.CourseNameMaxLength)] 
    public string Name { get; set; } = null!;

    [Unicode]
    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public ICollection<Resource> Resources { get; set; }

    public ICollection<Homework> Homeworks { get; set; }

    public ICollection<StudentCourse> StudentsCourses { get; set; }
}
