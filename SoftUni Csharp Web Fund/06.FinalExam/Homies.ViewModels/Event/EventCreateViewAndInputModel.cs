namespace Homies.ViewModels.Event;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Type;
using static Common.Validations.EventConstants;

public class EventCreateViewAndInputModel
{
    public EventCreateViewAndInputModel()
    {
        this.Types = new HashSet<TypeViewModel>();
    }

    public int EventId { get; set; }

    [Required]
    [StringLength(NameMax, MinimumLength = NameMin)]
    public string? Name { get; set; }

    [Required]
    [StringLength(DescriptionMax, MinimumLength = DescriptionMin)]
    public string? Description { get; set; }

    [Required]
    public string? Start { get; set; }

    [Required]
    public string? End { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int TypeId { get; set; }

    public ICollection<TypeViewModel> Types { get; set; }
}