namespace Contacts.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Seeding;
using Models.Entities;

internal class ContactEntityConfiguration : IEntityTypeConfiguration<Contact>
{
    private readonly ContactSeeder contactSeeder;

    public ContactEntityConfiguration()
    {
        this.contactSeeder = new ContactSeeder();
    }

    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasData(this.contactSeeder.SeedContacts());
    }
}