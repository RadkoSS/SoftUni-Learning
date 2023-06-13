namespace Contacts.Services;

using System.Data;
using Microsoft.EntityFrameworkCore;

using Data;
using Contracts;
using Data.Models.Entities;
using ViewModels.Contact;

public class ContactsService : IContactsService
{
    private readonly ContactsDbContext dbContext;

    public ContactsService(ContactsDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<AllContactsViewModel> GetAllContactsAsync()
    {
        var allContactsViewModel = new AllContactsViewModel
        {
            Contacts = await this.dbContext.Contacts.AsNoTracking().Select(c => new ContactViewModel
            {
                ContactId = c.Id,
                Email = c.Email,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address,
                PhoneNumber = c.PhoneNumber,
                Website = c.Website
            }).ToListAsync()
        };

        return allContactsViewModel;
    }

    public async Task<ContactViewModel> GetContactByIdAsync(string id)
    {
        var searchedContact = await this.dbContext.Contacts.FirstAsync(c => c.Id == int.Parse(id));

        var contactViewModel = new ContactViewModel
        {
            ContactId = searchedContact.Id,
            FirstName = searchedContact.FirstName,
            LastName = searchedContact.LastName,
            Address = searchedContact.Address,
            PhoneNumber = searchedContact.PhoneNumber,
            Website = searchedContact.Website,
            Email = searchedContact.Email
        };

        return contactViewModel;
    }

    public async Task<AllContactsViewModel> GetUserContactsByIdAsync(string userId)
    {
        var userContacts = await this.dbContext.ApplicationUserContacts.AsNoTracking()
            .Where(c => c.ApplicationUserId == userId)
            .Select(c => new ContactViewModel
            {
                ContactId = c.Contact.Id,
                Email = c.Contact.Email,
                FirstName = c.Contact.FirstName,
                LastName = c.Contact.LastName,
                Address = c.Contact.Address,
                PhoneNumber = c.Contact.PhoneNumber,
                Website = c.Contact.Website
            })
            .ToListAsync();

        var userTeam = new AllContactsViewModel
        {
            UserId = userId,
            Contacts = userContacts
        };

        return userTeam;
    }

    public async Task CreateContactAsync(ContactInputModel input)
    {
        var newContact = new Contact
        {
            FirstName = input.FirstName,
            LastName = input.LastName,
            Email = input.Email,
            Address = input.Address,
            PhoneNumber = input.PhoneNumber,
            Website = input.Website
        };

        await this.dbContext.Contacts.AddAsync(newContact);

        await this.dbContext.SaveChangesAsync();
    }

    public async Task AddContactToUserTeamAsync(string contactId, string userId)
    {
        if (this.dbContext.ApplicationUserContacts.Any(ac => ac.ApplicationUserId == userId && ac.ContactId == int.Parse(contactId)))
        {
            throw new DataException("Contact is already in team.");
        }

        var userContact = new ApplicationUserContact
        {
            ApplicationUserId = userId,
            ContactId = int.Parse(contactId)
        };

        await this.dbContext.ApplicationUserContacts.AddAsync(userContact);

        await this.dbContext.SaveChangesAsync();
    }

    public async Task RemoveContactFromUserTeamAsync(string userId, string contactId)
    {
        var userContactToRemove = await 
            this.dbContext.ApplicationUserContacts.AsNoTracking().Where(c =>
                c.ContactId == int.Parse(contactId) && c.ApplicationUserId == userId).FirstAsync();

        this.dbContext.ApplicationUserContacts.Remove(userContactToRemove);

        await this.dbContext.SaveChangesAsync();
    }

    public async Task EditContactAsync(ContactInputModel input)
    {
        var contactToEdit = await this.dbContext.Contacts.FirstAsync(c => c.Id == input.ContactId);

        contactToEdit.Email = input.Email;
        contactToEdit.Website = input.Website;
        contactToEdit.FirstName = input.FirstName;
        contactToEdit.LastName = input.LastName;
        contactToEdit.PhoneNumber = input.PhoneNumber;
        contactToEdit.Address = input.Address;

        this.dbContext.Contacts.Update(contactToEdit);

        await this.dbContext.SaveChangesAsync();
    }
}