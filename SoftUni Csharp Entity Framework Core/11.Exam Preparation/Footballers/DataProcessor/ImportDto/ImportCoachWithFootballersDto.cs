namespace Footballers.DataProcessor.ImportDto;

using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

using GlobalConstants;

[XmlType("Coach")]
public class ImportCoachWithFootballersDto
{
    [Required]
    [XmlElement("Name")]
    [StringLength(ValidationConstants.CoachNameMaxLength, MinimumLength = ValidationConstants.CoachNameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement("Nationality")]
    public string Nationality { get; set; } = null!;

    [XmlArray("Footballers")]
    public ImportFootballerDto[] Footballers { get; set; } = null!;
}