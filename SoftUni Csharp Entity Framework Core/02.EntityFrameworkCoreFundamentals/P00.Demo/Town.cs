using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace P00.Demo;
public partial class Town
{
    public Town()
    {
        Minions = new HashSet<Minion>();
    }

    [Key]
    public int Id { get; set; }
    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }
    public int? CountryCode { get; set; }

    [ForeignKey(nameof(CountryCode))]
    [InverseProperty(nameof(Country.Towns))]
    public virtual Country? CountryCodeNavigation { get; set; }
    [InverseProperty(nameof(Minion.Town))]
    public virtual ICollection<Minion> Minions { get; set; }
}