using System.ComponentModel.DataAnnotations;

namespace Rzucidlo.ChristmasApp.Core.Models;

public sealed class Present
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public Children Children { get; set; } = new();
}