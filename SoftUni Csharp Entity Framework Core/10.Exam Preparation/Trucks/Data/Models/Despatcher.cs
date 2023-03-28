namespace Trucks.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Despatcher
{
    public Despatcher()
    {
        this.Trucks = new HashSet<Truck>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Position { get; set; } = null!;

    public ICollection<Truck> Trucks { get; set; }
}