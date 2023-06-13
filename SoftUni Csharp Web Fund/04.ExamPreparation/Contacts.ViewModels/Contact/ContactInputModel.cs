namespace Contacts.ViewModels.Contact;

using System.ComponentModel.DataAnnotations;

using static Common.Validations.ContactsValidations;

public class ContactInputModel
{
    [Required]
    public int ContactId { get; set; }

    [Required]
    [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
    public string Email { get; set; } = null!;

    [Required]
    [RegularExpression(PhonePattern)]
    [StringLength(PhoneMaxLength, MinimumLength = PhoneMinLength)]
    public string PhoneNumber { get; set; } = null!;

    public string? Address { get; set; }

    [Required]
    [RegularExpression(WebsitePattern)]
    public string Website { get; set; } = null!;
}