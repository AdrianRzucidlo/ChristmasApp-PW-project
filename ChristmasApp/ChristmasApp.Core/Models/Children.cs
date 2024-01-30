using Rzucidlo.ChristmasApp.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rzucidlo.ChristmasApp.Core.Models;

[Table("Childers")] //yes, i know about the typo
public class Children
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(0, 18)]
    public int Age { get; set; }

    [Required]
    [MaxLength(100)]
    public string Address { get; set; } = string.Empty;

    [Required]
    public ChildrenBehaviourType ChildrenBehaviourType { get; set; }

    public virtual ICollection<Present> Presents { get; init; } = new List<Present>();
}