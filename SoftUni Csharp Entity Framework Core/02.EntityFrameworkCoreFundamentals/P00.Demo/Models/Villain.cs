using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace P00.Demo.Models
{
    public partial class Villain
    {
        public Villain()
        {
            Minions = new HashSet<Minion>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Name { get; set; }
        public int? EvilnessFactorId { get; set; }

        [ForeignKey(nameof(EvilnessFactorId))]
        [InverseProperty("Villains")]
        public virtual EvilnessFactor? EvilnessFactor { get; set; }

        [ForeignKey("VillainId")]
        [InverseProperty(nameof(Minion.Villains))]
        public virtual ICollection<Minion> Minions { get; set; }
    }
}
