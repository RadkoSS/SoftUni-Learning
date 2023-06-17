namespace Homies.Data.Models.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

using static Common.Validations.EventConstants;

public class Event
{
    public Event()
    {
        this.CreatedOn = DateTime.UtcNow;
        this.EventsParticipants = new HashSet<EventParticipant>();
    }

    public int Id { get; set; }

    [Required]
    [StringLength(NameMax)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(DescriptionMax)]
    public string Description { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Organiser))]
    public string OrganiserId { get; set; } = null!;

    [Required]
    public IdentityUser Organiser { get; set; } = null!;

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    public DateTime Start { get; set; }

    [Required]
    public DateTime End { get; set; }

    [Required]
    [ForeignKey(nameof(Type))]
    public int TypeId { get; set; }

    [Required]
    public Type Type { get; set; } = null!;

    public ICollection<EventParticipant> EventsParticipants { get; set; }
}