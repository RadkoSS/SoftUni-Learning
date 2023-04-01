namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Common;

[XmlType("Boardgame")]
public class ImportBoardgameDto
{
    [Required]
    [XmlElement("Name")]
    [MinLength(ValidationConstants.BoardgameNameMinLength)]
    [MaxLength(ValidationConstants.BoardgameNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement("Rating")]
    [Range(ValidationConstants.BoardgameRatingMinValue, ValidationConstants.BoardgameRatingMaxValue)]
    public double Rating { get; set; }

    [Required]
    [XmlElement("YearPublished")]
    [Range(ValidationConstants.BoardgameYearPublishedMinValue, ValidationConstants.BoardgameYearPublishedMaxValue)]
    public int YearPublished { get; set; }

    [Required]
    [XmlElement("CategoryType")]
    [Range(ValidationConstants.BoardgameCategoryTypeMinValue, ValidationConstants.BoardgameCategoryTypeMaxValue)]
    public int CategoryType { get; set; }

    [Required]
    [XmlElement("Mechanics")]
    public string Mechanics { get; set; } = null!;
}