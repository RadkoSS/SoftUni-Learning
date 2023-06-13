namespace Contacts.ViewModels.User;

using System.ComponentModel.DataAnnotations;

using static Common.Validations.ApplicationUserValidations;

public class RegisterInputViewModel
{
    [Required]
    [Display(Name = "Username")]
    [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
    public string UserName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
    public string Password { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
    [Compare(nameof(Password), ErrorMessage = "Password and Confirm password must match.")]
    public string ConfirmPassword { get; set; } = null!;
    
    public string? ReturnUrl { get; set; }
}