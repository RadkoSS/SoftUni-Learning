namespace Contacts.Data.Models.Entities;

using System.ComponentModel.DataAnnotations;

using static Common.Validations.ContactsValidations;

public class Contact
{
    public Contact()
    {
        this.ApplicationUserContacts = new HashSet<ApplicationUserContact>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(FirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(LastNameMaxLength)]
    public string LastName { get; set; } = null!;

    [Required]
    [StringLength(EmailMaxLength)]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(PhoneMaxLength)]
    public string PhoneNumber { get; set; } = null!;
    
    public string? Address { get; set; }

    [Required]
    public string Website { get; set; } = null!;
    
    public virtual ICollection<ApplicationUserContact> ApplicationUserContacts { get; set; }
}