namespace Footballers.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using GlobalConstants;

public class ImportTeamDto
{
    public ImportTeamDto()
    {
        this.Footballers = new HashSet<int>();
    }

    [Required]
    [RegularExpression(ValidationConstants.TeamNamePattern)]
    [StringLength(ValidationConstants.TeamNameMaxLength, MinimumLength = ValidationConstants.TeamNameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(ValidationConstants.TeamNationalityMaxLength, MinimumLength = ValidationConstants.TeamNationalityMinLength)]
    public string Nationality { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue)]
    public int Trophies { get; set; }

    public ICollection<int> Footballers { get; set; }
}