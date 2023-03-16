// ReSharper disable IdentifierTypo
namespace CarDealer.Models;

using Newtonsoft.Json;

public class Car
{
    public Car()
    {
        this.Sales = new HashSet<Sale>();
        this.PartsCars = new HashSet<PartCar>();
    }

    public int Id { get; set; }

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    [JsonProperty("traveledDistance")] //For Judge...
    public long TravelledDistance { get; set; }

    public ICollection<Sale> Sales { get; set; }  

    public ICollection<PartCar> PartsCars { get; set; }
}