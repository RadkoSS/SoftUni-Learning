namespace Footballers.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Footballer")]
public class ExportFootballerDto
{
    public string Name { get; set; } = null!;
    
    public string Position { get; set; } = null!;
}