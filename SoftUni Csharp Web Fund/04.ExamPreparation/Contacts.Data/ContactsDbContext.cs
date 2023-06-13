namespace Contacts.Data;

using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Models.Entities;

public class ContactsDbContext : IdentityDbContext
{
    public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
        : base(options)
    {}

    public DbSet<Contact> Contacts { get; set; } = null!;

    public DbSet<ApplicationUserContact> ApplicationUserContacts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ContactsDbContext)) ??
                                                Assembly.GetExecutingAssembly());

        builder.Entity<ApplicationUserContact>().HasKey(pk => new
        {
            pk.ApplicationUserId,
            pk.ContactId
        });

        base.OnModelCreating(builder);
    }
}