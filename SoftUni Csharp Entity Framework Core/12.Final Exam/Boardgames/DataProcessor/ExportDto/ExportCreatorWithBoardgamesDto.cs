namespace Boardgames.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Creator")]
public class ExportCreatorWithBoardgamesDto
{
    [XmlElement("CreatorName")]
    public string CreatorFullName { get; set; } = null!;

    [XmlAttribute("BoardgamesCount")]
    public int BoardgamesCount { get; set; }

    [XmlArray("Boardgames")]
    public ExportBoardgameDto[] Boardgames { get; set; } = null!;
}