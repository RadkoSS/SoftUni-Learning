namespace Trucks.DataProcessor.ImportDto;

using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

[XmlType("Despatcher")]
public class ImportDespatcherDto
{
    [Required]
    [StringLength(40, MinimumLength = 2)]
    public string Name { get; set; } = null!;

    [Required]
    public string Position { get; set; } = null!;

    [XmlArray("Trucks")]
    public ImportDespatcherTrucksDto[] Trucks { get; set; } = null!;
}