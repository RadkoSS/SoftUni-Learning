namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

public class ImportClientDto
{
    public ImportClientDto()
    {
        this.Trucks = new HashSet<int>();
    }

    [Required]
    [StringLength(40, MinimumLength = 3)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(40, MinimumLength = 2)]
    public string Nationality { get; set; } = null!;

    public string Type { get; set; } = null!;

    public ICollection<int> Trucks { get; set; }
}