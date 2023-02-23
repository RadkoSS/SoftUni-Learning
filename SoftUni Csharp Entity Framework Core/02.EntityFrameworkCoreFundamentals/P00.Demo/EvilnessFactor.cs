using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace P00.Demo;
public partial class EvilnessFactor
{
    public EvilnessFactor()
    {
        Villains = new HashSet<Villain>();
    }

    [Key]
    public int Id { get; set; }
    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }

    [InverseProperty(nameof(Villain.EvilnessFactor))]
    public virtual ICollection<Villain> Villains { get; set; }
}