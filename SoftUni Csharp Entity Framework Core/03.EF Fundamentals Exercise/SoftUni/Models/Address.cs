using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SoftUni.Models;

public class Address
{
    public Address()
    {
        this.Employees = new HashSet<Employee>();
    }

    [Column("TownID")]
    public int? TownId { get; set; }

    [ForeignKey(nameof(TownId))]
    [InverseProperty("Addresses")]
    public virtual Town? Town { get; set; }

    [Key]
    [Column("AddressID")]
    public int AddressId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string AddressText { get; set; } = null!;

    [InverseProperty(nameof(Employee.Address))]
    public virtual ICollection<Employee> Employees { get; set; }
}