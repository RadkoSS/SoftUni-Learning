namespace Trucks.DataProcessor.ImportDto;

using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

[XmlType("Truck")]
public class ImportDespatcherTrucksDto
{
    [Required]
    [StringLength(8, MinimumLength = 8)]
    [RegularExpression(@"^[A-Z]{2}\d{4}[A-Z]{2}$")]
    public string RegistrationNumber { get; set; } = null!;

    [Required]
    [StringLength(17, MinimumLength = 17)]
    public string VinNumber { get; set; } = null!;

    [Range(950, 1420)]
    public int TankCapacity { get; set; }

    [Range(5000, 29000)]
    public int CargoCapacity { get; set; }

    [Required]
    [Range(0, 3)]
    public int CategoryType { get; set; }

    [Required]
    [Range(0, 4)]
    public int MakeType { get; set; }
}