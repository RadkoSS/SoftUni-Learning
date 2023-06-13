namespace Contacts.ViewModels.User;

using System.ComponentModel.DataAnnotations;

using static Common.Validations.ApplicationUserValidations;

public class LoginInputViewModel
{
    [Required]
    [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength, ErrorMessage = "UserName must be at least {2} symbols long.")]
    public string UserName { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "Password must be at least {2} symbols long.")]
    public string Password { get; set; } = null!;
}