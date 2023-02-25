namespace SoftUni.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Minion
    {
        public Minion()
        {
            Villains = new HashSet<Villain>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? Name { get; set; }
        public int? Age { get; set; }
        public int? TownId { get; set; }

        [ForeignKey(nameof(TownId))]
        [InverseProperty("Minions")]
        public virtual Town? Town { get; set; }

        [ForeignKey("MinionId")]
        [InverseProperty(nameof(Villain.Minions))]
        public virtual ICollection<Villain> Villains { get; set; }
    }
}
