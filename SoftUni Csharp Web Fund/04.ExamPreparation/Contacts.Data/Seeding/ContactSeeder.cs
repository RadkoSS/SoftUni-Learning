namespace Contacts.Data.Seeding;

using Models.Entities;

internal class ContactSeeder
{
    internal Contact[] SeedContacts()
    {
        return new HashSet<Contact>
        {
            new Contact
            {
                Id = 1,
                FirstName = "Bruce",
                LastName = "Wayne",
                PhoneNumber = "+359881223344",
                Address = "Gotham City",
                Email = "imbatman@batman.com",
                Website = "www.batman.com"
            },
            new Contact
            {
                Id = 2,
                FirstName = "Spas",
                LastName = "Skrutchov",
                PhoneNumber = "+359881696969",
                Address = "Pernik City",
                Email = "iamscrutch@scrutch.bg",
                Website = "www.scrutch.bg"
            }
        }.ToArray();
    }
}