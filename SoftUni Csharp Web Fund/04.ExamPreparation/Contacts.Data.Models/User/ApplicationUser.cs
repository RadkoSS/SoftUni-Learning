namespace Contacts.Data.Models.User;

using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

using Entities;
using static Common.Validations.ApplicationUserValidations;

public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
        this.ApplicationUserContacts = new HashSet<ApplicationUserContact>();
    }

    [Required]
    [StringLength(UsernameMaxLength)]
    public override string UserName
    {
        get => base.UserName;
        set => base.UserName = value;
    }

    [Required]
    [StringLength(EmailMaxLength)]
    public override string Email
    {
        get => base.Email;
        set => base.Email = value;
    }

    public virtual ICollection<ApplicationUserContact> ApplicationUserContacts { get; set; } = null!;
}