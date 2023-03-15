// ReSharper disable IdentifierTypo
namespace CarDealer.DTOs.Import;

using Newtonsoft.Json;

public class ImportCarDto
{
    public ImportCarDto()
    {
        this.PartsCollection = new HashSet<int>();
    }

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    [JsonProperty("traveledDistance")]
    public long TravelledDistance { get; set; }

    [JsonProperty("partsId")]
    public ICollection<int> PartsCollection { get; set; }
}