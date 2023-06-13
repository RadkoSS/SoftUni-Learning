﻿namespace Contacts.Data.Models.Entities;

using System.ComponentModel.DataAnnotations.Schema;

using User;

public class ApplicationUserContact
{
    [ForeignKey(nameof(ApplicationUser))]
    public string ApplicationUserId { get; set; } = null!;

    public virtual ApplicationUser ApplicationUser { get; set; } = null!;

    [ForeignKey(nameof(Contact))]
    public int ContactId { get; set; }

    public virtual Contact Contact { get; set; } = null!;
}