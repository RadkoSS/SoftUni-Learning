namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Enums;

public class Homework
{
    [Key]
    public int HomeworkId { get; set; }

    public string Content { get; set; } = null!;

    public ContentTypes ContentType { get; set; }

    public DateTime SubmissionTime { get; set; }

    [ForeignKey(nameof(Student))]
    public int StudentId { get; set; }

    public Student Student { get; set; } = null!;

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }

    public Course Course { get; set; } = null!;
}
