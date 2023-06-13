namespace Contacts.ViewModels.Contact;

public class AllContactsViewModel
{
    public string UserId { get; set; } = null!;

    public ICollection<ContactViewModel> Contacts { get; set; } = null!;
}