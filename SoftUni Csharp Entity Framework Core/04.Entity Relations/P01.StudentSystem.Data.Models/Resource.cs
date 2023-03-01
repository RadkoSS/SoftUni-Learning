namespace P01_StudentSystem.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Enums;
using Common;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }

    [Unicode] 
    [MaxLength(GlobalConstants.ResourceMaxLength)]
    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public ResourceTypes ResourceType { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }

    public Course Course { get; set; } = null!;
}
