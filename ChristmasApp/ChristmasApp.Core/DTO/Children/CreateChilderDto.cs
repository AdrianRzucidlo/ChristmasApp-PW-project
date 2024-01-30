using Rzucidlo.ChristmasApp.Core.Enums;
using Rzucidlo.ChristmasApp.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Rzucidlo.ChristmasApp.Core.DTO.Children;

public record CreateChildrenDto : IChildren
{
    [Required]
    [MaxLength(50)]
    public string Name { get; init; } = string.Empty;

    [Required]
    [Range(0, 18)]
    public int Age { get; init; }

    [Required]
    [MaxLength(100)]
    public string Address { get; init; } = string.Empty;

    [Required]
    public ChildrenBehaviourType ChildrenBehaviourType { get; init; }
}