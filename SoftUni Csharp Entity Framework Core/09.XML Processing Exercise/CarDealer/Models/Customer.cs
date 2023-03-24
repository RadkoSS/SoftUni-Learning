namespace CarDealer2.Models;

public class Customer
{
    public Customer()
    {
        this.Sales = new HashSet<Sale>();
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public bool IsYoungDriver { get; set; }

    public virtual ICollection<Sale> Sales { get; set; }
}