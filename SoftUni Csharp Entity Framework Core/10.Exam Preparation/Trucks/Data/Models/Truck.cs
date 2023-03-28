namespace Trucks.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Enums;

public class Truck
{
    public Truck()
    {
        this.ClientsTrucks = new HashSet<ClientTruck>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string RegistrationNumber { get; set; } = null!;

    [Required]
    public string VinNumber { get; set; } = null!;

    [Required]
    public int TankCapacity { get; set; }

    [Required]
    public int CargoCapacity { get; set; }

    [Required]
    public CategoryType CategoryType { get; set; }

    [Required]
    public MakeType MakeType { get; set; }

    [Required]
    [ForeignKey(nameof(Despatcher))]
    public int DespatcherId { get; set; }

    public Despatcher Despatcher { get; set; } = null!;

    public ICollection<ClientTruck> ClientsTrucks { get; set; }
}