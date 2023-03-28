﻿namespace Trucks.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Client
{
    public Client()
    {
        this.ClientsTrucks = new HashSet<ClientTruck>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Nationality { get; set; } = null!;

    [Required]
    public string Type { get; set; } = null!;

    public ICollection<ClientTruck> ClientsTrucks { get; set; }
}