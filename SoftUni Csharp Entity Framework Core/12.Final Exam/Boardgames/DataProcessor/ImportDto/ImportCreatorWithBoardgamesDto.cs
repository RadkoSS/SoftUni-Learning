namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Common;

[XmlType("Creator")]
public class ImportCreatorWithBoardgamesDto
{
    [Required]
    [MinLength(ValidationConstants.CreatorFirstNameMinLength)]
    [MaxLength(ValidationConstants.CreatorFirstNameMaxLength)]
    [XmlElement("FirstName")]
    public string FirstName { get; set; } = null!;

    [Required]
    [MinLength(ValidationConstants.CreatorLastNameMinLength)]
    [MaxLength(ValidationConstants.CreatorLastNameMaxLength)]
    [XmlElement("LastName")]
    public string LastName { get; set; } = null!;

    [XmlArray("Boardgames")]
    public ImportBoardgameDto[] Boardgames { get; set; } = null!;
}