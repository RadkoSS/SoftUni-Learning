﻿namespace CarDealer.DTOs.Import;

using System.Xml.Serialization;

[XmlType("partId")]
public class ImportPartCarDto
{
    [XmlAttribute("id")]
    public int PartId { get; set; }
}