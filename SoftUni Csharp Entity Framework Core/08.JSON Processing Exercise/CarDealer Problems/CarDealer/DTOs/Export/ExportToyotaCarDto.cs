namespace CarDealer.DTOs.Export;

using Newtonsoft.Json;

public class ExportToyotaCarDto
{
    public int Id { get; set; }

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    [JsonProperty("TraveledDistance")]
    public long TravelledDistance { get; set; }
}