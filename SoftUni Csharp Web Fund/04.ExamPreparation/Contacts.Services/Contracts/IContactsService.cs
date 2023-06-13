namespace Contacts.Services.Contracts;

using ViewModels.Contact;

public interface IContactsService
{
    Task<AllContactsViewModel> GetAllContactsAsync();

    Task<ContactViewModel> GetContactByIdAsync(string id);

    Task<AllContactsViewModel> GetUserContactsByIdAsync(string userId);

    Task CreateContactAsync (ContactInputModel input);

    Task AddContactToUserTeamAsync(string contactId, string userId);

    Task RemoveContactFromUserTeamAsync(string userId, string contactId);
    Task EditContactAsync(ContactInputModel input);
}