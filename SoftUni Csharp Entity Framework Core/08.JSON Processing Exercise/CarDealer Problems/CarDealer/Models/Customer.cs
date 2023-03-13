﻿namespace CarDealer.Models;

public class Customer
{
    public Customer()
    {
        this.Sales = new List<Sale>();
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public bool IsYoungDriver { get; set; }

    public ICollection<Sale> Sales { get; set; }
}