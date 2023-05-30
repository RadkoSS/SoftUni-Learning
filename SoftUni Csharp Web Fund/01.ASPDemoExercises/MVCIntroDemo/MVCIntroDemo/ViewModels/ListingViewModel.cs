namespace MVCIntroDemo.ViewModels;

using System.ComponentModel.DataAnnotations;

public class ListingViewModel
{
    public ListingViewModel()
    {
        this.Id = Guid.NewGuid().ToString();
    }

    [Required]
    public string Id { get; set; }

    [Required]
    public string Make { get; set; } = null!;

    [Required]
    public string Model { get; set; } = null!;

    [Required]
    public string UploadDate { get; set; } = null!;

    [Required]
    public string ImageUrl { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }
}