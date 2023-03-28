namespace Trucks.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Despatcher")]
public class ExportDespatchersAndTrucksDto
{
    [XmlElement("DespatcherName")]
    public string Name { get; set; } = null!;

    [XmlAttribute("TrucksCount")]
    public int TrucksCount { get; set; }

    [XmlArray("Trucks")]
    public ExportTruckDto[] Trucks { get; set; } = null!;
}