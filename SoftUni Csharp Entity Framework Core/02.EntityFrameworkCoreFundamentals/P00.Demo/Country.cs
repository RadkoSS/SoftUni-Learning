using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace P00.Demo
{
    public partial class Country
    {
        public Country()
        {
            Towns = new HashSet<Town>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Name { get; set; }

        [InverseProperty(nameof(Town.CountryCodeNavigation))]
        public virtual ICollection<Town> Towns { get; set; }
    }
}
