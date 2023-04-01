namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Common;

public class ImportSellerDto
{
    public ImportSellerDto()
    {
        this.Boardgames = new HashSet<int>();
    }

    [Required]
    [MinLength(ValidationConstants.SellerNameMinLength)]
    [MaxLength(ValidationConstants.SellerNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(ValidationConstants.SellerAddressMinLength)]
    [MaxLength(ValidationConstants.SellerAddressMaxLength)]
    public string Address { get; set; } = null!;

    [Required]
    public string Country { get; set; } = null!;

    [Required]
    [RegularExpression(ValidationConstants.SellerWebsiteDomainPattern)]
    public string Website { get; set; } = null!;

    [Required]
    public ICollection<int> Boardgames { get; set; }
}