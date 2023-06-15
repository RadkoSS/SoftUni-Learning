namespace Library.Data.Models.Entities;

using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

public class IdentityUserBook
{
    [ForeignKey(nameof(Collector))]
    public string CollectorId { get; set; } = null!;

    public virtual IdentityUser Collector { get; set; } = null!;

    [ForeignKey(nameof(Book))]
    public int BookId { get; set; }

    public virtual Book Book { get; set; } = null!;
}