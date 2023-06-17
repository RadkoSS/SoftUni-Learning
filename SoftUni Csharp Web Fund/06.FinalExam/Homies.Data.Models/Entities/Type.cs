namespace Homies.Data.Models.Entities;

using System.ComponentModel.DataAnnotations;

using static Common.Validations.TypeConstants;

public class Type
{
    public Type()
    {
        this.Events = new HashSet<Event>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(NameMax)]
    public string Name { get; set; } = null!;

    public ICollection<Event> Events { get; set; }
}