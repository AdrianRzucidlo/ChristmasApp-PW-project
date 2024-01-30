using Rzucidlo.ChristmasApp.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Rzucidlo.ChristmasApp.Core.DTO.Present;

public record CreatePresentDto : IPresent
{
    [Required]
    [MaxLength(100)]
    public string Name { get; init; } = string.Empty;
}