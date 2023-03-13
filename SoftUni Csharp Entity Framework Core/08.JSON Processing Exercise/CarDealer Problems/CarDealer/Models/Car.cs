﻿// ReSharper disable IdentifierTypo
namespace CarDealer.Models;

public class Car
{
    public Car()
    {
        this.Sales = new List<Sale>();
        this.PartsCars = new List<PartCar>();
    }

    public int Id { get; set; }

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public long TravelledDistance { get; set; }

    public ICollection<Sale> Sales { get; set; }  

    public ICollection<PartCar> PartsCars { get; set; }
}